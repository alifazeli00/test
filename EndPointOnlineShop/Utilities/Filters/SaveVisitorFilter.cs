using Application.Visitor;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EndPointOnlineShop.Utilities.Filters
{
    public class SaveVisitorFilter : IActionFilter
    {
        private readonly ISaveVisitor SaveVisitor;
        public SaveVisitorFilter(ISaveVisitor SaveVisitor)
        {
            this.SaveVisitor=SaveVisitor;

        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
      
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string ip = context.HttpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            var actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
            var controllerName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ControllerName;
            var referer = context.HttpContext.Request.Headers["Referer"].ToString();
            var currentUrl = context.HttpContext.Request.Path;
            var Request = context.HttpContext.Request;
            string visitorId = context.HttpContext.Request.Cookies["VisitorId"];
            SaveVisitor.Execute(new VisitorDto { CurrentLink = currentUrl, Ip = ip, ReferrerLink = referer, PhysicalPath = $"{controllerName}/{ actionName}", VisitorId = visitorId, Time = System.DateTime.Now });

        }
    }
}
