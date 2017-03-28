using System.Collections.ObjectModel;
using System.Web;

namespace MiniMvc.Routing {
    public class RouteCollection : Collection<RouteBase> {
        public RouteData GetRouteData(HttpContextBase httpContext) {
            foreach(var route in Items) {
               var routeData= route.GetRouteData(httpContext);
                if (routeData != null) return routeData;
            }
            return null;
        }
    }
}