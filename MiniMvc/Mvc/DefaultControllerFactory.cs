using MiniMvc.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;

namespace MiniMvc.Mvc {
    public class DefaultControllerFactory : IControllerFactory {
        private static List<Type> controllerTypeCache = new List<Type>();
        static DefaultControllerFactory() => controllerTypeCache.AddRange(BuildManager.GetReferencedAssemblies().Cast<Assembly>().SelectMany(ab => ab.GetTypes()).Where(ty => typeof(IController).IsAssignableFrom(ty)));
        public IController CreateController(RequestContext requestContext, string controllerName) {
            controllerName += "Controller";
            Type controllerType = controllerTypeCache.FirstOrDefault(ty => string.Compare(ty.Name, controllerName, true) == 0);
            if (controllerType == null) return null;
            return (IController)Activator.CreateInstance(controllerType);
        }
    }
}