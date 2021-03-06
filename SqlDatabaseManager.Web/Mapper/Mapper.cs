﻿using SqlDatabaseManager.Domain.Connection;
using SqlDatabaseManager.Web.Models;
using System;

namespace SqlDatabaseManager.Web.Mapper
{
    internal class Mapper
    {
        internal static ConnectionInformationDTO ConnectionInformationMapper(ConnectionInformationViewModel connectionViewModel)
        {
            ValidateState(connectionViewModel);

            return MapModel(connectionViewModel);
        }

        #region ConnectionInformation

        private static void ValidateState(ConnectionInformationViewModel connectionViewModel)
        {
            if (connectionViewModel == null)
                throw new InvalidOperationException(string.Format(Domain.Properties.Resources.MappingError, nameof(connectionViewModel)));

            if (!connectionViewModel.DatabaseType.HasValue)
                throw new InvalidOperationException(string.Format(Domain.Properties.Resources.MappingError, nameof(connectionViewModel.DatabaseType)));
        }

        private static ConnectionInformationDTO MapModel(ConnectionInformationViewModel connectionViewModel)
        {
            return new ConnectionInformationDTO
            {
                ServerAddresss = connectionViewModel.ServerAddress,
                Login = connectionViewModel.Login,
                Password = connectionViewModel.Password,
                DatabaseType = connectionViewModel.DatabaseType.Value,
            };
        }

        #endregion ConnectionInformation
    }
}