using System;

namespace MAVN.Service.SmsProviderMock.Client.Models
{
    /// <summary>
    /// Represents an sms
    /// </summary>
     public class SmsResponseModel
    {
        /// <summary>
        /// The Timestamp of when the sms was sent
        /// </summary>
        public DateTimeOffset Timestamp { get; set; }
        
        /// <summary>
        /// The MessageId of the sms message
        /// </summary>
        public Guid MessageId { get; set; }
        
        /// <summary>
        /// The PhoneNumber to which the sms was sent
        /// </summary>
        public string PhoneNumber { get; set; }
        
        /// <summary>
        /// The Message content of the sms
        /// </summary>
        public string Message { get; set; }
    }
}
