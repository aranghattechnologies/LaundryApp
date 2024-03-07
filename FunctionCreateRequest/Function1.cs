using LaundryApp.Data;
using LaundryApp.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;
using System.Text.Json;

namespace FunctionCreateRequest
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;
        private readonly LaundryAppContext context;

        public Function1(ILogger<Function1> logger, LaundryAppContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [Function("Function1")]
        [OpenApiOperation(operationId: "Run")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(string), Description = "The OK response")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            var content = await new StreamReader(req.Body).ReadToEndAsync();
            Customer c = JsonSerializer.Deserialize<Customer>(content);

            await context.Customers.AddAsync(c);
            await context.SaveChangesAsync();

            return new OkObjectResult(new { c.Name, c.Email});
        }
    }
}
