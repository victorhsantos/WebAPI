using Alura.WebAPI.Api.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Alura.WebAPI.Api.Filtros
{
    public class ErrorResponseFilter : IExceptionFilter
    {
        /// <summary>
        /// Encapsula objeto do ErrorResponse quando ocorrer um erro nas validacoes do AspNet Core.
        /// </summary>
        /// <param name="context">contexto da requisicao</param>
        public void OnException(ExceptionContext context)
        {
            var erroResponse = ErrorResponse.From(context.Exception);
            context.Result = new ObjectResult(erroResponse) { StatusCode = 500 };
        }
    }
}
