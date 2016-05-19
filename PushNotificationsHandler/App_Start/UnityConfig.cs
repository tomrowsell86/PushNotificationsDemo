using System;
using System.Net;
using System.Security;
using System.Web.Http;
using Microsoft.Practices.Unity;
using Unity.WebApi;
using Microsoft.Practices.Unity.Configuration;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Factories;
using PushNotificationsHandler.Models.Services;
using PushNotificationsHandler.Repositories;
using PushNotificationsHandler.Repositories.Interface;

namespace PushNotificationsHandler.App_Start
{
    public class UnityConfig
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> _container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return _container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance<IMessageRepository>(new InMemoryMessageRepository());
            container.RegisterType<IFormatParser, FormatParser>();
            container.RegisterType<IMessageModelFactory, FormattedMessageModelFactory>();
            container.RegisterType<IMessageModelService, MessageModelService>();
            container.RegisterType<IRestClient, RestClient>(
                new InjectionConstructor(
                    new NetworkCredential("tom.rowsell@esendex.com", "tVmGgPwEmKEL"), 
                    new ApiEndpoint("v1.0",new Uri("https://api.esendex.com"))));
            container.RegisterInstance<IDeliveryNotificationRepository>(new InMemoryDeliveryNotificationRepository());
            container.RegisterType<ISentMessageService, SentMessageService>();
        }
    }
}
