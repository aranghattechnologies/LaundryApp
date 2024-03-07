// Default URL for triggering event grid function in the local environment.
// http://localhost:7071/runtime/webhooks/EventGrid?functionName={functionname}

using System;
using Azure.Messaging;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace FunctionEventGridListner
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function(nameof(Function1))]
        public async Task Run([EventGridTrigger] CloudEvent cloudEvent)
        {
             var data = await new StreamReader(cloudEvent.Data.ToStream()).ReadToEndAsync();
            _logger.LogInformation("Event type: {type}, Event subject: {subject}, {data}", cloudEvent.Type, cloudEvent.Subject,data);
        }
    }
}
