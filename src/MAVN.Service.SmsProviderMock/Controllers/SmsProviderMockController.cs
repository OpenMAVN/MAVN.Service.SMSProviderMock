using System;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Lykke.Service.NotificationSystemBroker.SmsProviderClient;
using Lykke.Service.NotificationSystemBroker.SmsProviderClient.Enums;
using Lykke.Service.SmsProviderMock.Client;
using Lykke.Service.SmsProviderMock.Client.Models;
using Lykke.Service.SmsProviderMock.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Lykke.Service.SmsProviderMock.Controllers
{
    [Route("/api/")]
    [ApiController]
    public class SmsProviderMockController : Controller, ISmsProviderMockApi, ISmsProvider
    {
        private readonly ISmsService _smsService;
        private readonly IMapper _mapper;

        public SmsProviderMockController(ISmsService smsService, IMapper mapper)
        {
            _smsService = smsService;
            _mapper = mapper;
        }

        /// <inheritdoc/>
        /// <response code="200">Success</response>
        [HttpPost("sms")]
        [SwaggerOperation("SendSmsAsync")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<SmsSenderResult> SendSmsAsync(SendSmsRequestModel model)
        {
            var isSuccessful = await _smsService.CreateAsync(model.MessageId, model.PhoneNumber, model.Message);

            var result = new SmsSenderResult {Result = SmsResult.Ok};

            if (isSuccessful)
            {
                return result;
            }

            result.Result = SmsResult.Error;
            result.ErrorMessage = "Error saving to database";

            return result;
        }

        /// <inheritdoc/>
        /// <response code="200">Success</response>
        [HttpPost("sms/query/")]
        [SwaggerOperation("RetrievePaginatedSmsAsync")]
        [ProducesResponseType((int) HttpStatusCode.OK)]
        public async Task<PaginatedSmsResponseModel> RetrievePaginatedSmsAsync(PaginatedSmsRequestModel model)
        {
            var paginatedSmsModel = await _smsService.RetrievePaginatedSmsAsync(model.CurrentPage, model.PageSize, model.PhoneNumber, model.MessageId);

            return _mapper.Map<PaginatedSmsResponseModel>(paginatedSmsModel);
        }

        /// <inheritdoc/>
        /// <response code="200">Success</response>
        [HttpDelete("sms/{messageId}")]
        [SwaggerOperation("DeleteAsync")]
        [ProducesResponseType((int) HttpStatusCode.NoContent)]
        public async Task DeleteAsync(Guid messageId)
        {
            await _smsService.DeleteAsync(messageId);
        }
    }
}
