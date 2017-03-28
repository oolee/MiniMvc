namespace MiniMvc.Routing {
    public class RouteTable {
        public static RouteCollection Routes { get; private set; }
        static RouteTable() => Routes = new RouteCollection();
    }
}