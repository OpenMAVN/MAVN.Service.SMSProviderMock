using AutoMapper;
using MAVN.Service.SmsProviderMock.Client.Models;
using MAVN.Service.SmsProviderMock.Domain.Entities;
using MAVN.Service.SmsProviderMock.Domain.Models;

namespace MAVN.Service.SmsProviderMock.Profiles
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
