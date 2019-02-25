using Autofac;
using SqlDatabaseManager.Base.Database;
using SqlDatabaseManager.Base.Login;
using SqlDatabaseManager.Base.Query;
using SqlDatabaseManager.Logic.Database;
using SqlDatabaseManager.Logic.Login;
using SqlDatabaseManager.Logic.Query;
using System;

namespace SqlDatabaseManager.Configuration
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
    }
}