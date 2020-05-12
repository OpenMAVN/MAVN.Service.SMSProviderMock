using JetBrains.Annotations;

namespace MAVN.Service.SmsProviderMock.Settings
{
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public class SmsProviderMockSettings
    {
        public DbSettings Db { get; set; }
    }
}
