using Autofac;
using JetBrains.Annotations;
using Lykke.Common.MsSql;
using Lykke.Service.SmsProviderMock.Domain.Repositories;
using Lykke.Service.SmsProviderMock.MsSqlRepositories;
using Lykke.Service.SmsProviderMock.MsSqlRepositories.Repositories;
using Lykke.Service.SmsProviderMock.Settings;
using Lykke.SettingsReader;

namespace Lykke.Service.SmsProviderMock.Modules
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
            builder.RegisterMsSql(
                _connectionString,
                connString => new SmsContext(connString, false),
                dbConn => new SmsContext(dbConn));

            builder.RegisterType<SmsRepository>()
                .As<ISmsRepository>()
                .SingleInstance();
        }
    }
}
