using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using SqlDatabaseManager.Base.Logics;
using SqlDatabaseManager.Base.Repositories;
using SqlDatabaseManager.Logic;
using SqlDatabaseManager.Repository;

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
                RegisterRepository(container);

                return container;
            });
        }

        private static void RegisterLogic(ContainerBuilder container)
        {
            container.RegisterType<LoginLogic>().As<ILoginLogic>();
        }

        private static void RegisterRepository(ContainerBuilder container)
        {
            container.RegisterType<MsSqlRepository>().As<IDatabaseRepository>();
        }
    }
}
