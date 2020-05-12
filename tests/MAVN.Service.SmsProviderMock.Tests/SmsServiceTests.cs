using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Lykke.Logs;
using MAVN.Service.SmsProviderMock.Domain.Entities;
using MAVN.Service.SmsProviderMock.Domain.Models;
using MAVN.Service.SmsProviderMock.Domain.Repositories;
using MAVN.Service.SmsProviderMock.DomainServices.Services;
using Moq;
using Xunit;

namespace MAVN.Service.SmsProviderMock.Tests
{
    public class SmsServiceTests
    {
        private readonly Mock<ISmsRepository> _smsRepositoryMock = new Mock<ISmsRepository>();
        private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
        private readonly SmsService _service;

        public SmsServiceTests()
        {
            _service = new SmsService(_smsRepositoryMock.Object, _mapperMock.Object, EmptyLogFactory.Instance);
        }

        [Fact]
        public async Task When_ParametersPassedToCreateAsync_Expect_MethodCalled()
        {
            //Arrange
            _smsRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(It.IsAny<bool>()));

            //Act
            await _service.CreateAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>());

            //Assert
            _smsRepositoryMock.Verify(x => x.CreateAsync(It.IsAny<Guid>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public async Task When_NonPositiveCurrentPagePassedToRetrievePaginatedSms_Expect_ExceptionThrown()
        {
            await Assert.ThrowsAsync<ArgumentException>(() => 
                _service.RetrievePaginatedSmsAsync(0, 2, It.IsAny<string>(), It.IsAny<string>()));
        }

        [Fact]
        public async Task When_NonPositivePageSizePassedToRetrievePaginatedSms_Expect_ExceptionThrown()
        {
            await Assert.ThrowsAsync<ArgumentException>(() =>
                _service.RetrievePaginatedSmsAsync(2, 0, It.IsAny<string>(), It.IsAny<string>()));
        }

        [Fact]
        public async Task When_CorrectParametersPassedToRetrievePaginatedSms_Expect_MethodCalledWithCorrectParameters()
        {
            //Arrange
            var currentPage = 2;
            var pageSize = 8;

            var skip = (currentPage - 1) * pageSize;
            var take = pageSize;

            _smsRepositoryMock.Setup(x => x.RetrievePaginatedSmsAsync(skip, take, It.IsAny<string>(), It.IsAny<string>()))
                .Returns(Task.FromResult(new PaginatedSmsModel
                {
                    Sms = It.IsAny<IEnumerable<ISms>>(),
                    TotalPageCount = currentPage + 1
                }));

            //Act
            var result = await _service.RetrievePaginatedSmsAsync(currentPage, pageSize, It.IsAny<string>(), It.IsAny<string>());
            
            //Assert
            _smsRepositoryMock.Verify(x => x.RetrievePaginatedSmsAsync(skip, take, It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            Assert.Equal(currentPage, result.CurrentPage);
        }

        [Fact]
        public async Task When_ParametersPassedToDeleteAsync_Expect_MethodCalled()
        {
            //Arrange
            _smsRepositoryMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(It.IsAny<bool>()));

            //Act
            await _service.DeleteAsync(It.IsAny<Guid>());

            //Assert
            _smsRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Once);
        }
    }
}
