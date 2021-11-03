using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Microsoft.Extensions.Logging;

namespace Travel.Application.Common.Behaviors
{
    public class LoggingBehaviors<TRequest> : IRequestPreProcessor<TRequest>
    {
        ILogger _logger;
        
        
        
        public async Task Process(TRequest request, CancellationToken cancellationToken)
        {
            var requestName = typeof(TRequest).Name;
            _logger.LogInformation("Travel Request: {@Request}", requestName, request);
        }
    }
}
