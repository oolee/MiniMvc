using MiniMvc.Mvc;
using System.Collections.Generic;
using System.Web;

namespace MiniMvc.Routing {
    public class Route : RouteBase {
        public string Url { get; set; }
        public IRouteHandler RouteHandler { get; set; }
        public Route() {
            RouteHandler = new MvcRouteHandler();
        }
        public override RouteData GetRouteData(HttpContextBase httpContext) {
            string path = httpContext.Request.AppRelativeCurrentExecutionFilePath.Substring(2);//"~/controller/action"
            if(Match(path,out var variables)) {
                RouteData routeData = new RouteData();
                foreach (var variable in variables) routeData.Values.Add(variable.Key, variable.Value);
                routeData.RouteHandler = RouteHandler;
                return routeData;
            }
            return null;
        }
        private bool Match(string requestUrl, out Dictionary<string, object> variables) {
            variables = new Dictionary<string, object>();
            string[] requestSplits = requestUrl.Split('/'), urlSplits = Url.Split('/');
            if (requestSplits.Length != urlSplits.Length) return false;

            for (int i = 0; i < requestSplits.Length; i++) {
                if (urlSplits[i].StartsWith("{") && urlSplits[i].EndsWith("}")) variables.Add(urlSplits[i].Trim("{}".ToCharArray()).ToLower(), requestSplits[i]);
                else if (string.Compare(urlSplits[i], requestSplits[i], true) != 0) return false;
            }

            return true;
        }
    }
}