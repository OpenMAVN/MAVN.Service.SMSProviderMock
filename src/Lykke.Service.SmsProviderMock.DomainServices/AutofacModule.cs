using Autofac;
using Lykke.Service.SmsProviderMock.Domain.Services;
using Lykke.Service.SmsProviderMock.DomainServices.Services;

namespace Lykke.Service.SmsProviderMock.DomainServices
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SmsService>()
                .As<ISmsService>()
                .SingleInstance();
        }
    }
}
