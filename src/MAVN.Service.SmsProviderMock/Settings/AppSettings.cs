using JetBrains.Annotations;
using Lykke.Sdk.Settings;

namespace Lykke.Service.SmsProviderMock.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class AppSettings : BaseAppSettings
    {
        public SmsProviderMockSettings SmsProviderMockService { get; set; }
    }
}
