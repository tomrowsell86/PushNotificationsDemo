using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using PushNotificationsHandler.Models;

namespace PushNotificationsHandler.App_Start
{
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
             container.RegisterType<IInboundProcessor, ProductRepository>();
        }
    }
}
