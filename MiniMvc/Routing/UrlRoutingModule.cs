using System;
using System.Web;
using System.Web.Routing;

namespace MiniMvc.Routing {
    public class UrlRoutingModule : IHttpModule {
        public void Dispose() { }

        public void Init(HttpApplication context)=> context.PostResolveRequestCache += OnPostResolveRequestCache;
        public virtual void OnPostResolveRequestCache(object sender, EventArgs e) {
            HttpContextWrapper wrapper = new HttpContextWrapper(HttpContext.Current);
            RouteData routeData = RouteTable.Routes.GetRouteData(wrapper);
            if (routeData == null) return;

            var requestContext = new RequestContext(wrapper,routeData);
            var routeHandler = routeData.RouteHandler?.GetHttpHandler(requestContext);
            if (routeHandler == null) return;

            wrapper.RemapHandler(routeHandler);
        }
    }
}