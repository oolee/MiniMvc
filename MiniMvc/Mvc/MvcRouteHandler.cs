using MiniMvc.Routing;
using System.Web;

namespace MiniMvc.Mvc {
    public class MvcRouteHandler : IRouteHandler {
        public IHttpHandler GetHttpHandler(RequestContext requestContext) => new MvcHandler(requestContext);
    }
}