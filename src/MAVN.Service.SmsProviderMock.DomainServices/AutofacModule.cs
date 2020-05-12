using Autofac;
using MAVN.Service.SmsProviderMock.Domain.Services;
using MAVN.Service.SmsProviderMock.DomainServices.Services;

namespace MAVN.Service.SmsProviderMock.DomainServices
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
