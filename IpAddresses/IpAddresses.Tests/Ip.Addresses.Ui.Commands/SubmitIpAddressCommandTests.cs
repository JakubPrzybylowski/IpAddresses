using Ip.Addresses.UI.Commands;
using Ip.Addresses.UI.DialogServices;
using Ip.Addresses.UI.Mappers;
using Ip.Addresses.UI.Models;
using Ip.Addresses.UI.ViewModels;
using IpAddresses.Domain.Models;
using IpAddresses.EF.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IpAddresses.Tests.Ip.Addresses.Ui.Commands
{
    public class SubmitIpAddressCommandTests
    {
        private IPDetailsViewModel _viewModel;
        private Mock<IIpAddressService> _ipAddressService;
        private IPDetailMapper _mapper;
        private ICommand _submitIpAddressCommand;
        private Mock<IDialogService> _dialogService;

        [SetUp]
        public void SetUp()
        {
            _ipAddressService = new Mock<IIpAddressService>();
            _viewModel = new IPDetailsViewModel();
            _mapper = new IPDetailMapper();
            _dialogService = new Mock<IDialogService>();
            _submitIpAddressCommand = new SubmitIpAddressCommand(_viewModel, _mapper, _ipAddressService.Object, _dialogService.Object);
            _dialogService.Setup(p => p.ShowMessageBox(It.IsAny<string>()));
            _viewModel.IpAddresses = new ObservableCollection<IpAddressDto>();
        }

        [Test]
        public void SubmitIpAddress_Should_AddIpAddressToIpAddresses()
        {
            _viewModel.IPAddressInput = "123.123.123.123";
            _ipAddressService.Setup(p => p.Create(_viewModel.IPAddressInput))
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

            _submitIpAddressCommand.Execute(null);
            Assert.Multiple(() =>
            {
                Assert.AreEqual(_viewModel.IpAddresses.First().Ip, "123.123.123.123");
                Assert.AreEqual(_viewModel.IpAddresses.First().Type, "ipv4");
                Assert.AreEqual(_viewModel.IpAddresses.First().ContinentCode, "NA");
                Assert.AreEqual(_viewModel.IpAddresses.First().ContinentName, "North America");
                Assert.AreEqual(_viewModel.IpAddresses.First().CountryCode, "US");
                Assert.AreEqual(_viewModel.IpAddresses.First().CountryName, "United States");
                Assert.AreEqual(_viewModel.IpAddresses.First().RegionCode, "CA");
                Assert.AreEqual(_viewModel.IpAddresses.First().RegionName, "California");
                Assert.AreEqual(_viewModel.IpAddresses.First().City, "Los Angeles");
                Assert.AreEqual(_viewModel.IpAddresses.First().Zip, "90013");
            });
        }

        [Test]
        public void SubmitIpAddressWhichIsNotFindByIpStack_Should_ReturnNullAndDonNotAddEmptyObjectToCollection()
        {
            var ipWhichNotExists = "999.999.123.999";
            _viewModel.IPAddressInput = ipWhichNotExists;
            _ipAddressService.Setup(p => p.Create(_viewModel.IPAddressInput))
                .Returns(Task.FromResult<IpAddress>(null));
            _submitIpAddressCommand.Execute(ipWhichNotExists);
            Assert.That(_viewModel.IpAddresses.Any(), Is.EqualTo(false));
        }
    }
}
