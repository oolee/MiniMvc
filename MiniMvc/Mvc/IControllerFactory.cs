using MiniMvc.Routing;

namespace MiniMvc.Mvc {
    public interface IControllerFactory {
        IController CreateController(RequestContext requestContext, string controllerName);
    }
}