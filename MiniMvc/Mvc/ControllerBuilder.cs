using System;

namespace MiniMvc.Mvc {
    public class ControllerBuilder {
        private static ControllerBuilder _instance = new ControllerBuilder();
        private Func<IControllerFactory> _factoryThunk = () => null;
        public ControllerBuilder Current => _instance;
        public IControllerFactory GetControllerFactory() => _factoryThunk();
        public void SetControllerFactory(IControllerFactory factory) => _factoryThunk = () => factory;
    }
}