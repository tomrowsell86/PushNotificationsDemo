using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using PushNotificationsHandler.Models;

namespace PushNotificationsHandler.App_Start
{
    public class UnityConfig
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return _container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
             container.RegisterType<IInboundProcessor, InboundProcessor>();
        }
    }
}
