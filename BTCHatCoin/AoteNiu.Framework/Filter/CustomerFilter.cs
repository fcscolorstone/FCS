using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AoteNiu.Framework
{
    /// <summary>
    /// 前端人员
    /// </summary>
    public class CustomerFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var redirect = new JsonResult(RspInfo.Login_Info_Invalid);
            redirect.ContentType = "application/json";

            var role = filterContext.HttpContext.Session.GetInt32("role");
            int? ucode = filterContext.HttpContext.Session.GetInt32("ucode");

            // 未登录
            if (role == null || ucode == null)
            {
                filterContext.Result = redirect;
                return;
            }

            return;
        }
    }

}
