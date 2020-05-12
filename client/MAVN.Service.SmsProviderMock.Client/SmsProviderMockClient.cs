using Lykke.HttpClientGenerator;
using MAVN.Service.NotificationSystemBroker.SmsProviderClient;

namespace MAVN.Service.SmsProviderMock.Client
{
    /// <summary>
    /// SmsProviderMock API aggregating interface.
    /// </summary>
    public class SmsProviderMockClient : ISmsProviderMockClient
    {
        // Note: Add similar MockApi properties for each new service controller

        /// <summary>Interface to SmsProviderMock Api.</summary>
        public ISmsProviderMockApi MockApi { get; private set; }

        /// <summary>
        /// Interface to SmsProvider Api.
        /// </summary>
        public ISmsProviderApi Api { get; private set; }

        /// <summary>C-tor</summary>
        public SmsProviderMockClient(IHttpClientGenerator httpClientGenerator)
        {
            MockApi = httpClientGenerator.Generate<ISmsProviderMockApi>();
        }
    }
}
