using Coladel.Core.Enums;
using Coladel.Core.Interfaces.Results;
using Coladel.Core.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Coladel.Core.Rest.Model;
using System.Linq;

namespace Coladel.Core.Rest.Controller
{
    public class RestController : ControllerBase
    {
        protected IActionResult Execute(Func<object> func)
        {
            try
            {
                var result = func.Invoke();

                if (result != null)
                {
                    if (result is IOperationResultBase)
                    {
                        return CreateResult_v2(result);
                    }

                    if (result is ResultadoOperacaoBase)
                    {
                        return CreateResult_v1(result);
                    }

                    return Ok(result);
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public static IActionResult CreateResult_v2(dynamic data)
        {
            var restResult = new RestResult();
            restResult.Messages = data.Messages;

            if (data.IsSuccessTypeResult)
            {
                var dataType = (Type)data.GetType();

                if (dataType == typeof(PaginatedResult))
                {
                    restResult.Data = data.Data;
                    restResult.TotalCount = data.TotalCount;
                    restResult.Count = data.Count;
                    restResult.Page = data.Page;
                    restResult.Pages = data.Pages;
                }
                else if (dataType.IsGenericType && dataType.GetGenericTypeDefinition() == typeof(OperationResult<>))
                {
                    restResult.Data = data.Data;
                }
            }

            return CreateActionResult(GetStatusCode(data.ResultType), restResult);
        }

        private static int GetStatusCode(EnumTypeResult typeResult)
        {
            switch (typeResult)
            {
                case EnumTypeResult.Ok:
                    return 200;

                case EnumTypeResult.Created:
                    return 201;

                case EnumTypeResult.Accepted:
                    return 202;

                case EnumTypeResult.InvalidInput:
                    return 400;

                case EnumTypeResult.NotFound:
                    return 404;

                case EnumTypeResult.Forbidden:
                    return 403;

                case EnumTypeResult.InternalError:
                    return 500;

                case EnumTypeResult.ServiceUnavaliable:
                    return 503;

                default:
                    return 200;
            }
        }

        private static IActionResult CreateResult_v1(dynamic data)
        {
            var restResult = new RestResult();
            var dataGenericType = data.GetType().GetGenericTypeDefinition();

            if (data.Mensagens != null && data.Mensagens.Count > 0)
                restResult.Messages = data.Mensagens;

            if (data.LogCodes != null && data.LogCodes.Count > 0)
            {
                if (restResult.Messages == null)
                    restResult.Messages = new List<string>();
                restResult.Messages.AddRange(data.LogCodes);
            }

            if (!string.IsNullOrWhiteSpace(data.MensagemPrincipal))
            {
                if (restResult.Messages == null)
                    restResult.Messages = new List<string>();

                restResult.Messages.Insert(0, data.MensagemPrincipal);
            }

            if (dataGenericType == typeof(ResultadoOperacao<>))
                restResult.Data = data.Modelo;

            if (dataGenericType == typeof(RetornoPaginacao<>))
            {
                restResult.Data = data.ListaRetorno;
                restResult.TotalCount = data.ContagemTotal;
                restResult.Count = data.ContagemPagina;
                restResult.Page = data.PaginaAtual;
                restResult.Pages = data.QtdPaginas;
            }

            return CreateActionResult(data.StatusCode, restResult);
        }

        private static bool ContainProperty(PropertyInfo[] properties, string propertyName)
        {
            return properties.Any(p => p.Name.Equals(propertyName));
        }

        private static IActionResult CreateActionResult(int statusCode, RestResult restResult)
        {
            var result = new ObjectResult(restResult);
            result.StatusCode = statusCode;
            return result;
        }
    }
}
