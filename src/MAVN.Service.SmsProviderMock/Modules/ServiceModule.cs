using Autofac;
using JetBrains.Annotations;

namespace MAVN.Service.SmsProviderMock.Modules
{
    [UsedImplicitly]
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DomainServices.AutofacModule());
        }
    }
}
