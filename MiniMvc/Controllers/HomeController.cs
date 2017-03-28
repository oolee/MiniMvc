using MiniMvc.Mvc;
using MiniMvc.Routing;

namespace MiniMvc.Controllers {
    public class HomeController : Controller {
        protected override void Execute(RequestContext requestContext) {
            base.Execute(requestContext);
            requestContext.HttpContext.Response.Write("Customer Data<br/>");
        }
    }
}