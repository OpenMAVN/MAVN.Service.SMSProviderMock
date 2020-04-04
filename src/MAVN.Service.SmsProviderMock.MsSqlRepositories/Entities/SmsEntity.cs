using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Lykke.Service.SmsProviderMock.Domain.Entities;

namespace Lykke.Service.SmsProviderMock.MsSqlRepositories.Entities
{
    [Table("sms")]
    public class SmsEntity : ISms
    {
        [Column("timestamp")]
        [Required]
        public DateTime Timestamp { get; set; }

        [Key]
        [Column("message_id")]
        [Required]
        public Guid MessageId { get; set; }

        [Column("phone_number")]
        [Required]
        [MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Column("message")]
        [MaxLength(10000)]
        public string Message { get; set; }

        public SmsEntity(Guid messageId, string phoneNumber, string message)
        {
            Timestamp = DateTime.UtcNow;
            MessageId = messageId;
            Message = message;
            PhoneNumber = phoneNumber;
        }
    }
}
