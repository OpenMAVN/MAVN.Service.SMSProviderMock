using JetBrains.Annotations;

namespace Lykke.Service.SmsProviderMock.Client
{
    /// <summary>
    /// SmsProviderMock client interface.
    /// </summary>
    [PublicAPI]
    public interface ISmsProviderMockClient
    {
        // Make your app's controller interfaces visible by adding corresponding properties here.
        // NO actual methods should be placed here (these go to controller interfaces, for example - ISmsProviderMockApi).
        // ONLY properties for accessing controller interfaces are allowed.

        /// <summary>Application MockApi interface</summary>
        ISmsProviderMockApi MockApi { get; }
    }
}
