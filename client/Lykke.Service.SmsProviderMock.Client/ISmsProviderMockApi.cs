using System;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Lykke.Service.SmsProviderMock.Client.Models;
using Refit;

namespace Lykke.Service.SmsProviderMock.Client
{
    /// <summary>
    /// SmsProviderMock client API interface.
    /// </summary>
    [PublicAPI]
    public interface ISmsProviderMockApi
    {
        /// <summary>
        /// Retrieves paged sms with options for phoneNumber and messageId filters
        /// </summary>
        /// <param name="model">Model containing request parameters for current page,
        /// page size, optional phoneNumber filter and optional messageId filter</param>
        /// <returns>Paginated list of sms</returns>
        [Post("api/sms/query/")]
        Task<PaginatedSmsResponseModel> RetrievePaginatedSmsAsync(PaginatedSmsRequestModel model);

        /// <summary>
        /// Deletes an sms with given messageId
        /// </summary>
        /// <param name="messageId">The messageId of the sms to delete</param>
        /// <returns>No Content</returns>
        [Delete("api/sms/{messageId}")]
        Task DeleteAsync(Guid messageId);
    }
}
