using System.ComponentModel.DataAnnotations;

namespace Lykke.Service.SmsProviderMock.Client.Models
{
    /// <summary>
    /// Model used for requesting paginated data for sms
    /// </summary>
    public class PaginatedSmsRequestModel
    {
        /// <summary>
        /// The current page
        /// </summary>
        [Required]
        [Range(1, int.MaxValue)]
        public int CurrentPage { get; set; }

        /// <summary>
        /// The page size
        /// </summary>
        [Required]
        [Range(1, 1000)]
        public int PageSize { get; set; }

        /// <summary>
        /// Optional PhoneNumber filter
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Optional MessageId filter
        /// </summary>
        public string MessageId { get; set; }
    }
}
