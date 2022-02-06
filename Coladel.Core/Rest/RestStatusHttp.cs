using Coladel.Core.Enum;
using Microsoft.AspNetCore.Mvc;

namespace Coladel.Core.Rest
{
    public class RestStatusHttp
    {
        public static IActionResult ReturnStatus(EnumTypeResult status, object result)
        {
            return status switch
            {
                EnumTypeResult.Ok => new OkObjectResult(result),
                EnumTypeResult.Created => new OkObjectResult(result),
                EnumTypeResult.Accepted => new OkObjectResult(result),
                EnumTypeResult.InvalidInput => new BadRequestObjectResult(result),
                EnumTypeResult.NotFound => new NotFoundObjectResult(result),
                EnumTypeResult.Forbidden => new NotFoundObjectResult(result),
                EnumTypeResult.InternalError => new BadRequestObjectResult(result),
                EnumTypeResult.ServiceUnavaliable => new BadRequestObjectResult(result),
                _ => new OkResult(),
            };
        }
    }
}
