using Autofac;
using SqlDatabaseManager.Application.Database;
using SqlDatabaseManager.Application.Connection;
using SqlDatabaseManager.Application.Authentication;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Query;
using System;

namespace SqlDatabaseManager.Application.Configuration
{
    public static class ServiceLocator
    {
        private static Lazy<ContainerBuilder> webContainer;

        public static ContainerBuilder WebContainer => webContainer.Value;

        static ServiceLocator()
        {
            webContainer = new Lazy<ContainerBuilder>(() =>
            {
                ContainerBuilder container = new ContainerBuilder();

                RegisterFactories(container);
                RegisterServices(container);
                RegisterSecurity(container);

                return container;
            });
        }

        private static void RegisterFactories(ContainerBuilder container)
        {
            container.RegisterType<DatabaseFactory>().As<IDatabaseFactory>();
            container.RegisterType<QueryFactory>().As<IQueryFactory>();
        }

        private static void RegisterServices(ContainerBuilder container)
        {
            container.RegisterType<ConnectionSerivce>().As<IConnectionSerivce>();
            container.RegisterType<DatabaseService>().As<IDatabaseService>();

            container.RegisterType<DatabaseConnectionApplicationService>().As<IDatabaseConnectionApplicationService>();
            container.RegisterType<DatabaseApplicationService>().As<IDatabaseApplicationService>();
        }

        private static void RegisterSecurity(ContainerBuilder container)
        {
            container.RegisterType<SessionMemory>().As<ISession>().SingleInstance();
        }
    }
}