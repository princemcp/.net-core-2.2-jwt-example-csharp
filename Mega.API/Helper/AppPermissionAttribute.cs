using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Mega.API.Helper
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AppPermissionAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private string[] _permission;
        public AppPermissionAttribute(params string[] permission)
        {
            _permission = permission;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
            {
                return;
            }

            //IRepository service = (IRepositoryWrapper)context.HttpContext.RequestServices.GetService(typeof(IRepository));
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;
            string Role = identity.Claims.Where(c => c.Type == "Role")
                       .Select(c => c.Value).SingleOrDefault();

            var controllerActionDescriptor = context.ActionDescriptor as ControllerActionDescriptor;
            string controllerName = controllerActionDescriptor?.ControllerName;
            string actionName = controllerActionDescriptor?.ActionName;


            var success = false;
            if (Role!="Admin")
            {
                //context.
                //context.Result = JsonFormatter.GetErrorJsonObject(CommonResource.error_unauthorized,
                //StatusCodeEnum.Forbidden);
                //context.Result = new UnauthorizedAccessException();
                context.Result = new UnauthorizedResult();
                //context
                //context.HttpContext.Abort();//..StatusCode = 401;
                return;
            }
            else
            {

            }


        }
    }
}