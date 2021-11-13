using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Travel.Application.Common.Behaviors
{
    public class UnhandledExeptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TRequest>
    {
        ILogger _logger;

        public Task<TRequest> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TRequest> next)
        {  
            try { return await next(); }
            catch (Exception ex)
            {
                var requestName = typeof(TRequest).Name;
                _logger.LogError(ex, "Travel Request: Unhandled Exeption for request {Name} {@Request}", requestName, request);
                throw;
            }
        }
    }
}
