using Lykke.SettingsReader.Attributes;

namespace Lykke.Service.SmsProviderMock.Client 
{
    /// <summary>
    /// SmsProviderMock client settings.
    /// </summary>
    public class SmsProviderMockServiceClientSettings 
    {
        /// <summary>Service url.</summary>
        [HttpCheck("api/isalive")]
        public string ServiceUrl {get; set;}
    }
}
