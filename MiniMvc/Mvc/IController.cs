using MiniMvc.Routing;

namespace MiniMvc.Mvc {
    public interface IController {
        void Execute(RequestContext requestContext);
    }
}