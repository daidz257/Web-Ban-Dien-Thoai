using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
namespace WebBanDienThoai.Models.Authentication
{
    public class Authentication:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if(context.HttpContext.Session.GetString("UserName")==null)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                        {
                            {"Controller", "Access" },
                            {"Action", "Login" }
                        }) ;
            }
            var db = new QlbanDienThoaiContext();
            var userName = context.HttpContext.Session.GetString("UserName");
            var user = db.TUsers.SingleOrDefault(u => u.Username == userName);
            if (user == null || user.LoaiUser != 1)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                    { "Controller", "Access" },
                    { "Action", "Login" }
                    });
            }
        }
    }
}
