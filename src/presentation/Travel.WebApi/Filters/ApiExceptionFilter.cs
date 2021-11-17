using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Filters;
using Travel.Application.Common.Exceptions;

namespace Travel.WebApi.Filters
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;

        public ApiExceptionFilter()
        {


        }

        public override void OnException(ExceptionContext context)
        {
            HandleException(context);
            base.OnException(context);
        }

        private void HandleException(ExceptionContext context)
        {


        }

        private void HandleUnknownException(ExceptionContext context)
        {


        }

        private void HandleValidationException(ExceptionContext context)
        {


        }

        private void HandleNofFoundException(ExceptionContext context)
        {


        }

    }
    
}
