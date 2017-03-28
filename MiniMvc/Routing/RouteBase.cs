using System.Web;

namespace MiniMvc.Routing {
    public abstract class RouteBase {
        public abstract RouteData GetRouteData(HttpContextBase httpContext);
    }
}