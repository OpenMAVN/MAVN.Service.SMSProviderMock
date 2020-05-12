using System;
using System.Threading.Tasks;
using MAVN.Service.SmsProviderMock.Domain.Models;

namespace MAVN.Service.SmsProviderMock.Domain.Services
{
    public interface ISmsService
    {
        Task<bool> CreateAsync(Guid messageId, string phoneNumber, string message);

        Task<PaginatedSmsModel> RetrievePaginatedSmsAsync(int currentPage, int pageSize, string phoneNumber, string messageId);

        Task DeleteAsync(Guid messageId);
    }
}
