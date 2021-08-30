using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace TaksaCheckIn.Models
{
    public class ForbiddenResult : IActionResult
    {
        private readonly HttpRequest _request;
        private readonly string _reason;

        public ForbiddenResult(HttpRequest request, string reason)
        {
            _request = request;
            _reason = reason;
        }

        public ForbiddenResult(HttpRequest request)
        {
            _request = request;
            _reason = "Forbidden";
        }

        public async Task ExecuteResultAsync(ActionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Forbidden;
            await context.HttpContext.Response.WriteAsync(_reason);

            await Task.FromResult(context);
        }
    }
}