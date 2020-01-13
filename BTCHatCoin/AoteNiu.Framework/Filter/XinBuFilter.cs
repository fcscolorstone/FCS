using log4net;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace AoteNiu.Framework
{
    /// <summary>
    /// 内部服务器调用
    /// </summary>
    public class XinBuFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var redirect = new JsonResult(RspInfo.Login_Info_Invalid);
            redirect.ContentType = "application/json";

            // 坑爹了，开启VPN会拦截header
            StringValues token = string.Empty;
            filterContext.HttpContext.Request.Headers.TryGetValue("token", out token);

            if (token.ToString() != CommonHelper.GetAppSetting<string>(AoteNiuConst.WEB_SECTION, "key"))
            {
                filterContext.Result = redirect;
                return;
            }
            
            return;
        }
    }

}
