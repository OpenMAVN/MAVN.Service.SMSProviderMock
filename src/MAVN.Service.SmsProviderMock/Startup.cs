using System;
using AutoMapper;
using JetBrains.Annotations;
using Lykke.Common.ApiLibrary.Filters;
using Lykke.Sdk;
using MAVN.Service.SmsProviderMock.Profiles;
using MAVN.Service.SmsProviderMock.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace MAVN.Service.SmsProviderMock
{
    [UsedImplicitly]
    public class Startup
    {
        private readonly LykkeSwaggerOptions _swaggerOptions = new LykkeSwaggerOptions
        {
            ApiTitle = "SmsProviderMock API",
            ApiVersion = "v1"
        };

        [UsedImplicitly]
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider<AppSettings>(options =>
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
        public void Configure(IApplicationBuilder app, IMapper mapper)
        {
            app.UseLykkeConfiguration(options =>
            {
                options.SwaggerOptions = _swaggerOptions;
            });

            mapper.ConfigurationProvider.AssertConfigurationIsValid();
        }
    }
}
