using System;
using System.Threading.Tasks;
using AutoMapper;
using Common.Log;
using Lykke.Common.Log;
using Lykke.Service.SmsProviderMock.Domain.Models;
using Lykke.Service.SmsProviderMock.Domain.Repositories;
using Lykke.Service.SmsProviderMock.Domain.Services;

namespace Lykke.Service.SmsProviderMock.DomainServices.Services
{
    public class SmsService : ISmsService
    {
        private readonly ISmsRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILog _log;

        public SmsService(ISmsRepository repository, IMapper mapper, ILogFactory logFactory)
        {
            _repository = repository;
            _mapper = mapper;
            _log = logFactory.CreateLog(this);
        }

        public Task<bool> CreateAsync(Guid messageId, string phoneNumber, string message)
        {
            return _repository.CreateAsync(messageId, phoneNumber, message);
        }

        public async Task<PaginatedSmsModel> RetrievePaginatedSmsAsync(int currentPage, int pageSize, string phoneNumber, string messageId)
        {
            if (currentPage < 1)
                throw new ArgumentException("Current page can't be negative or zero", nameof(currentPage));

            if (pageSize < 1)
                throw new ArgumentException("Page size can't be negative or zero", nameof(pageSize));
            
            var skip = (currentPage - 1) * pageSize;
            var take = pageSize;

            var paginatedSmsModel = await _repository.RetrievePaginatedSmsAsync(skip, take, phoneNumber, messageId);

            paginatedSmsModel.CurrentPage = currentPage;

            return paginatedSmsModel;
        }

        public async Task DeleteAsync(Guid messageId)
        {
            var success = await _repository.DeleteAsync(messageId);

            if (!success)
                _log.Info("Sms not found for deletion", context: messageId);
        }
    }
}
