using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MAVN.Service.SmsProviderMock.Domain.Entities;
using MAVN.Service.SmsProviderMock.Domain.Models;

namespace MAVN.Service.SmsProviderMock.Domain.Repositories
{
    public interface ISmsRepository
    {
        Task<bool> CreateAsync(Guid messageId, string phoneNumber, string message);

        Task<PaginatedSmsModel> RetrievePaginatedSmsAsync(int skip, int take, string phoneNumber, string messageId);

        Task<bool> DeleteAsync(Guid messageId);

        Task<IEnumerable<ISms>> GetLastFiftyTodaySmsAsync();

        Task<ISms> GetMessageByMessageIdAsync(Guid messageId);
    }
}
