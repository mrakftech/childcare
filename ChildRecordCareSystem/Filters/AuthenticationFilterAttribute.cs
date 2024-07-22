using Microsoft.AspNetCore.Mvc;

namespace ChildRecordCareSystem.Filters
{
    public class AuthenticationFilterAttribute : TypeFilterAttribute
    {
        public AuthenticationFilterAttribute() : base(typeof(AuthenticationFilter))
        {
        }
    }
}
