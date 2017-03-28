namespace MiniMvc.Routing {
    public class RouteData {
        public RouteValueDictionary Values { get; private set; }
        public IRouteHandler RouteHandler { get; set; }
        public RouteData() => Values = new RouteValueDictionary();
        public string Controller {
            get {
                if (Values.TryGetValue("controller", out var controller)) return controller.ToString();
                return string.Empty;
            }
        }
        public string Action {
            get {
                if (Values.TryGetValue("action", out var action)) return action.ToString();
                return string.Empty;
            }
        }
    }
}