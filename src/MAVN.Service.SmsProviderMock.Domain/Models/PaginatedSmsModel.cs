using System.Collections.Generic;
using MAVN.Service.SmsProviderMock.Domain.Entities;

namespace MAVN.Service.SmsProviderMock.Domain.Models
{
    public class PaginatedSmsModel
    {
        public IEnumerable<ISms> Sms { get; set; }

        public int TotalPageCount { get; set; }

        public int CurrentPage { get; set; }
    }
}
