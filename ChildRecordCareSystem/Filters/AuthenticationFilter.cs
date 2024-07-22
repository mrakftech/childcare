using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ChildRecordCareSystem.Filters
{
    public class AuthenticationFilter : IAsyncActionFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthenticationFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            string username = _httpContextAccessor.HttpContext.Session.GetString("Username");

            if (string.IsNullOrEmpty(username))  
            {
                context.Result = new RedirectToActionResult("Login", "Account", new { area = "Identity" });
                return;
            }

            await next();
        }

    }
}
