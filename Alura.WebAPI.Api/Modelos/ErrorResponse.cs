using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Linq;

namespace Alura.WebAPI.Api.Modelos
{
    public class ErrorResponse
    {
        public int Codigo { get; set; }
        public string Mensagem { get; set; }
        public ErrorResponse InnerError { get; set; }
        public string[] Detalhes { get; set; }

        /// <summary>
        /// Modelo de Retorno para Erro
        /// </summary>
        /// <param name="ex">Exception</param>
        /// <returns></returns>
        public static ErrorResponse From(Exception ex)
        {
            if (ex == null)
                return null;

            return new ErrorResponse
            {
                Codigo = ex.HResult,
                Mensagem = ex.Message,
                InnerError = ErrorResponse.From(ex.InnerException)
            };
        }


        public static ErrorResponse FromModelState(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(x => x.Errors);

            return new ErrorResponse
            {
                Codigo = 100,
                Mensagem = "Houve erro(s) no envio da requisicao.",
                Detalhes = erros.Select(e => e.ErrorMessage).ToArray()
            };
        }
    }
}
