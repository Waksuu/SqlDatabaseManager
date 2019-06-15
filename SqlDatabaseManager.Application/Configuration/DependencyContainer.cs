using Autofac;
using SqlDatabaseManager.Application.Authentication;
using SqlDatabaseManager.Application.Connection;
using SqlDatabaseManager.Application.Database;
using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Domain.Database;
using SqlDatabaseManager.Domain.Query;

namespace SqlDatabaseManager.Application.Configuration
{
    public static class DependencyContainer
    {
        public static ContainerBuilder WebContainer { get; }

        static DependencyContainer()
        {
            WebContainer = new ContainerBuilder();

            RegisterFactories(WebContainer);
            RegisterServices(WebContainer);
            RegisterSecurity(WebContainer);
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