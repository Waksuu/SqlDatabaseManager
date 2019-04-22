using Autofac;
using SqlDatabaseManager.Application.Database;
using SqlDatabaseManager.Application.Connection;
using SqlDatabaseManager.Application.Security;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Query;
using System;

namespace SqlDatabaseManager.Application.Configuration
{
    public static class ServiceLocator
    {
        private static bool _initialized = false;
        private static Lazy<ContainerBuilder> _webContainer;

        public static ContainerBuilder WebContainer => _webContainer.Value;

        static ServiceLocator()
        {
            if (_initialized)
            {
                return;
            }

            _webContainer = new Lazy<ContainerBuilder>(() =>
            {
                ContainerBuilder container = new ContainerBuilder();

                RegisterLogic(container);
                RegisterFactories(container);
                RegisterServices(container);
                RegisterSecurity(container);

                return container;
            });
        }

        private static void RegisterLogic(ContainerBuilder container)
        {
            container.RegisterType<LoginLogic>().As<ILoginLogic>();
            container.RegisterType<DatabaseLogic>().As<IDatabaseLogic>();
        }

        private static void RegisterFactories(ContainerBuilder container)
        {
            container.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();
            container.RegisterType<QueryFactory>().As<IQueryFactory>();
        }

        private static void RegisterServices(ContainerBuilder container)
        {
            container.RegisterType<DatabaseConnectionApplicationService>().As<IDatabaseConnectionApplicationService>();
            container.RegisterType<DatabaseApplicationService>().As<IDatabaseApplicationService>();
        }

        private static void RegisterSecurity(ContainerBuilder container)
        {
            container.RegisterType<SessionMemory>().As<ISession>().SingleInstance();
        }
    }
}