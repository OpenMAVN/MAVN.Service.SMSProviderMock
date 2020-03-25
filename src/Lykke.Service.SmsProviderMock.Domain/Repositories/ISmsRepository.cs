using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Service.SmsProviderMock.Domain.Entities;
using Lykke.Service.SmsProviderMock.Domain.Models;

namespace Lykke.Service.SmsProviderMock.Domain.Repositories
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
