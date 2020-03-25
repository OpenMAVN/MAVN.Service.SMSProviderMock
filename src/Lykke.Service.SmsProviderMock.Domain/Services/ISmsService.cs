using System;
using System.Threading.Tasks;
using Lykke.Service.SmsProviderMock.Domain.Models;

namespace Lykke.Service.SmsProviderMock.Domain.Services
{
    public interface ISmsService
    {
        Task<bool> CreateAsync(Guid messageId, string phoneNumber, string message);

        Task<PaginatedSmsModel> RetrievePaginatedSmsAsync(int currentPage, int pageSize, string phoneNumber, string messageId);

        Task DeleteAsync(Guid messageId);
    }
}
