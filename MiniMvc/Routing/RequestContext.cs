using System.Web;

namespace MiniMvc.Routing {
    public class RequestContext {
        public HttpContextBase HttpContext { get; set; }
        public RouteData RouteData { get; set; }
        public RequestContext(HttpContextBase httpContext,RouteData routeData) {
            HttpContext = httpContext;
            RouteData = routeData;
        }       
    }
}