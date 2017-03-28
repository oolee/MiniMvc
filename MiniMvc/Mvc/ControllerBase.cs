using MiniMvc.Routing;

namespace MiniMvc.Mvc {
    public abstract class ControllerBase : IController {
        protected virtual void Execute(RequestContext requestContext) => requestContext.HttpContext.Response.Write(GetType().FullName+"<br/>");
        void IController.Execute(RequestContext requestContext) => Execute(requestContext);
    }
}