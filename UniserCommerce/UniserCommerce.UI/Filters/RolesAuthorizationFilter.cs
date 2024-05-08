using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace UniserCommerce.UI.Filters
{
    public class RolesAuthorizationFilter : Attribute, IAuthorizationFilter
    {
        private readonly string[] _roles;

        public RolesAuthorizationFilter(params string[] roles)
        {
            _roles = roles ?? throw new ArgumentNullException(nameof(roles));
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectResult("/Authentication/Auth/AccessDenied");
                return;
            }

            // Check if the user is in any of the specified roles
            bool isAuthorized = _roles.Any(role => context.HttpContext.User.IsInRole(role));

            if (!isAuthorized)
            {
                context.Result = new ForbidResult();
                return;
            }
        }
    }
}
