using System;

namespace Lykke.Service.SmsProviderMock.Domain.Entities
{
    public interface ISms
    {
        /// <summary>
        /// Automatically set on insertion to database. Prior manipulation of value would not be saved.
        /// </summary>
        DateTime Timestamp { get; set; }

        Guid MessageId { get; set; }

        string PhoneNumber { get; set; }
        
        string Message { get; set; }
    }
}
