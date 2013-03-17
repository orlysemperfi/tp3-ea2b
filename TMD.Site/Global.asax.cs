using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace TMD.CF.Site
{
    public interface IContainerAccessor
    {
        IUnityContainer Container { get; }
    }

    public class Global : System.Web.HttpApplication, IContainerAccessor
    {
        private static IUnityContainer _container;

        public static IUnityContainer Container
        {
            get
            {
                return _container;
            }
            set
            {
                _container = value;
            }
        }

        IUnityContainer IContainerAccessor.Container
        {
            get
            {
                return Container;
            }
        }

        void Application_Start(object sender, EventArgs e)
        {
            BuildContainer();
        }

        void Application_End(object sender, EventArgs e)
        {
            CleanUp();
        }

        private static void BuildContainer()
        {
            UnityConfigurationSection section =
                            (UnityConfigurationSection)ConfigurationManager.GetSection("unity");

            IUnityContainer unitContainer = new UnityContainer();
            unitContainer.LoadConfiguration(section);
            Container = unitContainer;
        }

        private static void CleanUp()
        {
            if (Container != null)
            {
                Container.Dispose();
            }
        }

    }
}
