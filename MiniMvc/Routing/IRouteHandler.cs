using System.Web;

namespace MiniMvc.Routing {
    public interface IRouteHandler {
        IHttpHandler GetHttpHandler(RequestContext requestContext);
    }
}