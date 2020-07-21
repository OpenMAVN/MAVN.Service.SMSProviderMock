using System;
using Autofac;
using AutoMapper;
using JetBrains.Annotations;
using Lykke.Common.ApiLibrary.Filters;
using Lykke.Sdk;
using Lykke.SettingsReader;
using MAVN.Service.SmsProviderMock.Profiles;
using MAVN.Service.SmsProviderMock.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MAVN.Service.SmsProviderMock
{
    [UsedImplicitly]
    public class Startup
    {
        private IConfigurationRoot _configurationRoot;
        private IReloadingManager<AppSettings> _settingsManager;
        private readonly LykkeSwaggerOptions _swaggerOptions = new LykkeSwaggerOptions
        {
            ApiTitle = "SmsProviderMock API",
            ApiVersion = "v1"
        };

        [UsedImplicitly]
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson();
            (_configurationRoot, _settingsManager) = services.BuildServiceProvider<AppSettings>(options =>
            {
                options.Extend = (serviceCollection, settings) =>
                {
                    serviceCollection.AddAutoMapper(typeof(ServiceProfile));
                };

                options.ConfigureMvcOptions = b => b.Filters.Add(typeof(NoContentFilter));

                options.SwaggerOptions = _swaggerOptions;

                options.Logs = logs =>
                {
                    logs.AzureTableName = "SmsProviderMockLog";
                    logs.AzureTableConnectionStringResolver = settings => settings.SmsProviderMockService.Db.LogsConnString;
                };

            });
        }

        [UsedImplicitly]
        public void ConfigureContainer(ContainerBuilder builder)
        {
            {
                builder.ConfigureLykkeContainer(
                    _configurationRoot,
                    _settingsManager);
            }
        }

        [UsedImplicitly]
        public void Configure(
            IApplicationBuilder app,
            IMapper mapper,
            IApplicationLifetime appLifetime)
        {
            app.UseRouting().UseEndpoints(endpoints => { endpoints.MapControllers(); });
            app.UseLykkeConfiguration(appLifetime, options =>
            {
                options.SwaggerOptions = _swaggerOptions;
            });

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
