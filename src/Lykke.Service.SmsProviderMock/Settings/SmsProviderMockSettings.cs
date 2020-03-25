using JetBrains.Annotations;

namespace Lykke.Service.SmsProviderMock.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmsProviderMockSettings
    {
        public DbSettings Db { get; set; }
    }
}
