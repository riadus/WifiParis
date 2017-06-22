using Autofac;

namespace WifiParis.Setup
{
	public static class AppContainer
	{
		static IContainer _container;

		public static IContainer Container
		{
			get
			{
				return _container ?? (_container = new AppSetup().CreateContainer());
			}
		}

        public static void Init()
        {
            var x = Container;
        }
	}
}
