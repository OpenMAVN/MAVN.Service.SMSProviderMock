using AutoMapper;
using Lykke.Service.SmsProviderMock.Client.Models;
using Lykke.Service.SmsProviderMock.Domain.Entities;
using Lykke.Service.SmsProviderMock.Domain.Models;

namespace Lykke.Service.SmsProviderMock.Profiles
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<ISms, SmsResponseModel>();
            CreateMap<PaginatedSmsModel, PaginatedSmsResponseModel>();
        }
    }
}
