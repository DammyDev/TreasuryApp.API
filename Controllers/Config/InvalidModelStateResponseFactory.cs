using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TreasuryApp.API.Extensions;
using TreasuryApp.API.Resources;

namespace TreasuryApp.API.Controllers.Config
{
    public static class InvalidModelStateResponseFactory
    {
        public static IActionResult ProduceErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.GetErrorMessages();
            var response = new ErrorResource(messages: errors);
            
            return new BadRequestObjectResult(response);
        }
    }
}