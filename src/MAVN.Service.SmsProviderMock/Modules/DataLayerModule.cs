﻿using Autofac;
using JetBrains.Annotations;
using Lykke.SettingsReader;
using MAVN.Persistence.PostgreSQL.Legacy;
using MAVN.Service.SmsProviderMock.Domain.Repositories;
using MAVN.Service.SmsProviderMock.MsSqlRepositories;
using MAVN.Service.SmsProviderMock.MsSqlRepositories.Repositories;
using MAVN.Service.SmsProviderMock.Settings;

namespace MAVN.Service.SmsProviderMock.Modules
{
    [UsedImplicitly]
    public class DataLayerModule : Module
    {
        private readonly string _connectionString;

        public DataLayerModule(IReloadingManager<AppSettings> appSettings)
        {
            _connectionString = appSettings.CurrentValue.SmsProviderMockService.Db.DataConnString;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterPostgreSQL(
                _connectionString,
                connString => new SmsContext(connString, false),
                dbConn => new SmsContext(dbConn));

            builder.RegisterType<SmsRepository>()
                .As<ISmsRepository>()
                .SingleInstance();
        }
    }
}
