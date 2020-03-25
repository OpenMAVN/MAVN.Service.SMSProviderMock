using System.Collections.Generic;
using Lykke.Service.SmsProviderMock.Domain.Entities;

namespace Lykke.Service.SmsProviderMock.Domain.Models
{
    public class PaginatedSmsModel
    {
        public IEnumerable<ISms> Sms { get; set; }

        public int TotalPageCount { get; set; }

        public int CurrentPage { get; set; }
    }
}
