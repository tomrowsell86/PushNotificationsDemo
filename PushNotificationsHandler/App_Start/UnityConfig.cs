using System;
using System.Configuration;
using System.Net;
using System.Web.Http;
using Microsoft.Practices.Unity;
using PushNotificationsHandler.Models;
using PushNotificationsHandler.Models.Factories;
using PushNotificationsHandler.Models.Services;
using PushNotificationsHandler.Repositories;
using PushNotificationsHandler.Repositories.Interface;
using Unity.WebApi;

namespace PushNotificationsHandler
{
    public class UnityConfig
    {
        #region Unity Container
        private static readonly Lazy<IUnityContainer> Container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
            return container;
        });

        public static IUnityContainer GetConfiguredContainer()
        {
            return Container.Value;
        }
        #endregion

        public static void RegisterTypes(IUnityContainer container)
        {
            container.RegisterInstance<IMessageRepository>(new InMemoryMessageRepository());
            container.RegisterType<IFormatParser, FormatParser>();
            container.RegisterType<IMessageModelFactory, FormattedMessageModelFactory>();
            container.RegisterType<IMessageModelService, MessageModelService>();
            container.RegisterType<IRestClient, RestClient>(
                new InjectionFactory(c => new NetworkCredential(ConfigurationManager.AppSettings["esendexApiLogin"], ConfigurationManager.AppSettings["esendexApiPassword"])),
                new InjectionFactory(c=>
                    new ApiEndpoint("v1.0",new Uri("https://api.esendex.com"))));
            container.RegisterInstance<IDeliveryNotificationRepository>(new InMemoryDeliveryNotificationRepository());
            container.RegisterType<ISentMessageService, SentMessageService>();
        }
    }
}
