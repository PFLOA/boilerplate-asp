using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Coladel.Core.Utils
{
    public static class StringExtension
    {

        /// <summary>
        /// Reduz a quantidade de caracteres na string de acordo com o parametro passado
        /// </summary>
        /// <param name="texto">String para verificacao de tamanho</param>
        /// <param name="tamanho">Tamanho a ser setado na string</param>
        /// <returns>Uma nova cadeia de caracteres de acordo com o tamanho passado por parametro</returns>
        public static string CortarString(this string texto, int tamanho)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "";

            if (texto.Length > tamanho)
                texto = texto.Substring(0, tamanho);
            return texto;
        }

        public static string LimitaTexto(this string str, int inicio, int limite)
        {
            if (string.IsNullOrEmpty(str))
                return "";

            if (str.Length <= inicio)
            {
                return "";
            }
            else
            {
                if (str.Length - inicio <= limite)
                {
                    return str.Substring(inicio);
                }
                else
                {
                    return str.Substring(inicio, limite);
                }
            }
        }

        /// <summary>
        /// Verifica se a tring é nula ou vazia.
        /// </summary>
        /// <param name="text">String para verificação</param>
        /// <returns>True caso string esteja nula ou vazia</returns>
        public static bool IsNull(this string text)
        {
            return string.IsNullOrWhiteSpace(text);
        }

        /// <summary>
        /// Verifica se o CPF está estruturado de uma forma válida.
        /// </summary>
        /// <param name="cnpj">String com os numeros do cpf</param>
        /// <returns>False caso CPF seja inválido</returns>
        public static bool ValidarCpf(this string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf += digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cpf.EndsWith(digito);
        }

        /// <summary>
        /// Verifica se o CNPJ está estruturado de uma forma válida.
        /// </summary>
        /// <param name="cnpj">String com os numeros do CNPJ</param>
        /// <returns>False caso CNPJ seja inválido</returns>
        public static bool ValidarCNPJ(this string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj += digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito += resto.ToString();
            return cnpj.EndsWith(digito);
        }
        /// <summary>
        /// Verifica se o endereço de e-mail é válido.
        /// </summary>
        /// <param name="email">Endereço de e-mail</param>
        /// <returns>False caso e-mail seja inválido</returns>
        public static bool ValidarEmail(this string email)
        {
            Regex rg = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");

            if (rg.IsMatch(email))
                return true;

            return false;
        }

        /// <summary>
        /// Válida se o número de telfone atende aos padrões recentes(2020)
        /// </summary>
        /// <param name="telefone">String com numero do telefone</param>
        /// <returns>False caso número seja inválido</returns>
        public static bool ValidarTelefone(this string telefone)
        {
            telefone = telefone.ExtrairNumeros();

            if (telefone.Length < 10)
                return false;

            telefone = telefone.ToInt64().ToString();

            if (telefone.Length < 10)
                return false;

            return true;
        }

        /// <summary>
        /// Extrai caracteres numéricos da string.
        /// </summary>
        /// <param name="texto">string para remoção dos caracteres</param>
        /// <returns>String com os numéricos apenas</returns>
        public static string ExtrairNumeros(this string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return "";

            StringBuilder s = new StringBuilder();
            foreach (var c in texto)
            {
                if (char.IsDigit(c))
                    s.Append(c);
            }
            return s.ToString();
        }

        public static byte[] FromHex(string hex)
        {
            hex = hex.Replace("-", "");
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }


        public static string MascararNome(this string texto, int caracteresManter = 1)
        {
            if (texto == null)
                return null;

            if (string.IsNullOrWhiteSpace(texto))
                return null;

            if (caracteresManter < 1)
                caracteresManter = 1;

            StringBuilder sbRetorno = new StringBuilder();
            string[] nomes = texto.TrimEnd().Split(' ');
            foreach (var nome in nomes)
            {
                if (caracteresManter < nome.Length)
                    sbRetorno.Append(nome.Substring(0, caracteresManter).PadRight(nome.Length, '*'));
                else
                    sbRetorno.Append(nome);
                sbRetorno.Append(" ");
            }
            return sbRetorno.ToString().Trim();
        }

        /// <summary>
        /// Mascara endereço de e-mail.
        /// </summary>
        /// <param name="texto">endereço de e-mail</param>
        /// <param name="caracteresManter">caracteres a serem mantidos</param>
        /// <returns>E-mail com mascara</returns>
        public static string MascararEmail(this string texto, int caracteresManter = 1)
        {
            if (texto == null)
                return null;

            if (string.IsNullOrWhiteSpace(texto))
                return null;

            var partes = texto.Split('@');
            if (partes.Length == 2)
            {
                texto = partes[0].MascararNome(caracteresManter) + "@" + partes[1];
            }
            else
            {
                texto = texto.MascararNome(caracteresManter);
            }
            return texto;
        }
        /// <summary>
        /// Adiciona marcacoes na string do documento.
        /// </summary>
        /// <param name="documento">CPF(11 caracters) ou CNPJ(14 caracteres)</param>
        /// <param name="formatacaoInicial">Extrai os numeros da string</param>
        /// <returns>Documento formatado com pontuação</returns>
        public static string FormatarDocumento(this string documento, bool formatacaoInicial = true)
        {
            if (formatacaoInicial)
                documento = ExtrairNumeros(documento);

            if (documento.Length == 11)
            {
                documento = documento.Insert(9, "-");
                documento = documento.Insert(6, ".");
                documento = documento.Insert(3, ".");
            }
            else if (documento.Length == 14)
            {
                documento = documento.Insert(12, "-");
                documento = documento.Insert(8, "/");
                documento = documento.Insert(5, ".");
                documento = documento.Insert(2, ".");
            }
            else
            {
                return "";
            }

            return documento;
        }
        /// <summary>
        /// Verifica se contem o texto  na lista de strings, exato ou não.
        /// </summary>
        /// <param name="lista">Lista a ser pesquisada</param>
        /// <param name="textoProcurado">Texto a ser procurado</param>
        /// <param name="textoExato">True se necessario exatidao</param>
        /// <returns>True caso contenha</returns>
        public static bool ContemTexto(this List<string> lista, string textoProcurado, bool textoExato = false)
        {
            if (lista == null)
                return false;

            foreach (var text in lista)
            {
                if (textoExato && text.Equals(textoProcurado))
                {
                    return true;
                }
                else if (text.Contains(textoProcurado))
                {
                    return true;
                }
            }

            return false;
        }
        /// <summary>
        /// Transforma o valor decimal em string.
        /// </summary>
        /// <param name="value">Valor em decimal.</param>
        /// <param name="decimais">Número de decimais.</param>
        /// <returns>String formatada.</returns>
        public static string SeparadorDecimalComPonto(decimal value, short decimais)
        {
            return value.ToString("0." + "0".PadLeft(decimais, '0'), System.Globalization.CultureInfo.InvariantCulture);
        }
    }
}
