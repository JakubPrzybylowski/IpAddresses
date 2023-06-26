using IpAddresses.Domain.Models;
using IpAddresses.Domain.Services;
using IpAddresses.EF.Services;
using IpStackService;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddresses.Tests.IpAddresses.EF.Services
{
    public class IpAddressServiceTest
    {
        private IIpAddressService _ipAddressService;
        private Mock<IpStackService.IIpStackService> _ipStackServiceMock;
        private Mock<IBaseDataService<IpAddress>> _baseDataService;

        [SetUp]
        public void SetUp()
        {
            _ipStackServiceMock = new Mock<IIpStackService>();
            _baseDataService = new Mock<IBaseDataService<IpAddress>>();
            _ipAddressService = new IpAddressService(_ipStackServiceMock.Object, _baseDataService.Object);
        }

        [Test]
        public void GetIpAddress_Return_IpAddress_ThenCreateResult_ShouldHaveCorrectIpAddress()
        {
            _ipStackServiceMock.Setup(p => p.GetIpAddress(It.IsAny<string>())).Returns(Task.FromResult(new IpAddress()
            {
                Ip = "123.123.123.123",
                Type = "ipv4",
                ContinentCode = "NA",
                ContinentName = "North America",
                CountryCode = "US",
                CountryName = "United States",
                RegionCode = "CA",
                RegionName = "California",
                City = "Los Angeles",
                Zip = "90013"
            }));

            _baseDataService.Setup(p => p.Create(It.IsAny<IpAddress>()))
                .Returns(Task.FromResult(new IpAddress() 
                { 
                    Ip = "123.123.123.123",
                    Type = "ipv4",
                    ContinentCode = "NA",
                    ContinentName = "North America",
                    CountryCode = "US",
                    CountryName = "United States",
                    RegionCode = "CA",
                    RegionName = "California",
                    City = "Los Angeles",
                    Zip = "90013"
                }));
            var sut = _ipAddressService.Create("123.123.123.123");

            Assert.Multiple(() => {
                Assert.AreEqual(sut.Result.Ip, "123.123.123.123");
                Assert.AreEqual(sut.Result.Type, "ipv4");
                Assert.AreEqual(sut.Result.ContinentCode, "NA");
                Assert.AreEqual(sut.Result.ContinentName, "North America");
                Assert.AreEqual(sut.Result.CountryCode, "US");
                Assert.AreEqual(sut.Result.CountryName, "United States");
                Assert.AreEqual(sut.Result.RegionCode, "CA");
                Assert.AreEqual(sut.Result.RegionName, "California");
                Assert.AreEqual(sut.Result.City, "Los Angeles");
                Assert.AreEqual(sut.Result.Zip, "90013");
                });         
        }

        [Test]
        public void GetIpAddress_Return_Null_ThenCreateResult_ShoudBeNull()
        {
            _ipStackServiceMock.Setup(p => p.GetIpAddress(It.IsAny<string>())).Returns(Task.FromResult<IpAddress>(null));         

            var sut = _ipAddressService.Create("123.123.123.123");

            Assert.IsNull(sut.Result);
        }

        [Test]
        public void CreateWithEmptyIp_Should_Return_null()
        {
            var sut = _ipAddressService.Create("");

            Assert.IsNull(sut.Result);
        }

        [Test]
        public void GetIpAddress_Return_Exception_Then_CreateShould_ThrowException()
        {
            _ipStackServiceMock.Setup(p => p.GetIpAddress(It.IsAny<string>())).Throws(new Exception("ExceptionMassage"));
         
            Assert.That(() => _ipAddressService.Create("123.123.123.123"), 
                Throws.Exception.TypeOf<Exception>()
                .With.Message
                .EqualTo("ExceptionMassage"));
            
        }
    }
}
