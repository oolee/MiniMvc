using MiniMvc.Routing;
using System;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Linq;

namespace MiniMvc.Mvc {
    public class MvcHandler : IHttpHandler {
        public RequestContext RequestContext { get; private set; }
        public MvcHandler(RequestContext requestContext) => RequestContext = requestContext;
        public bool IsReusable => false;

        public void ProcessRequest(HttpContext context) {
            context.Response.Write("hello world<br/>");
            string controllerName =RequestContext.RouteData.Controller + "Controller";
            Type controllerType = GetControllerType(controllerName);
            if (controllerType == null) return;
            //IController controller = (IController)Activator.CreateInstance("MiniMvc", controllerName);
            IController controller = (IController)Activator.CreateInstance(controllerType);
            controller.Execute(RequestContext);
        }
        private Type GetControllerType(string controllerName) {
            foreach(Assembly assembly in BuildManager.GetReferencedAssemblies()) {
                var result = assembly.GetTypes().FirstOrDefault(ty => typeof(IController).IsAssignableFrom(ty) && string.Compare(ty.Name, controllerName) == 0);
                if (result != null) return result;
            }
            return null;
        }
    }
}