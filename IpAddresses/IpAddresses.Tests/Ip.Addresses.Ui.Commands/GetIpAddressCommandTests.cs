using Ip.Addresses.UI.Mappers;
using Ip.Addresses.UI.ViewModels;
using Ip.Addresses.UI.Commands;
using IpAddresses.EF.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Moq;
using IpAddresses.Domain.Models;
using Ip.Addresses.UI.DialogServices;

namespace IpAddresses.Tests.Ip.Addresses.Ui.Commands
{
    public class GetIpAddressCommandTests
    {
        private  IPDetailsViewModel _viewModel;
        private  Mock<IIpAddressService> _ipAddressService;
        private  IPDetailMapper _mapper;
        private  ICommand _getIpAddressCommand;
        private Mock<IDialogService> _dialogService;

        [SetUp]
        public void SetUp()
        {
            _ipAddressService = new Mock<IIpAddressService>();
            _viewModel= new IPDetailsViewModel();
            _mapper= new IPDetailMapper();
            _dialogService = new Mock<IDialogService>();
            _getIpAddressCommand = new GetIpAddressCommand(_viewModel,_mapper,_ipAddressService.Object, _dialogService.Object);
        }

        [Test]
        public void RunGetCommand_ReturnCorrectIpAddressesCount()
        {
            _dialogService.Setup(p => p.ShowMessageBox(It.IsAny<string>()));
            _ipAddressService.Setup(p => p.GetAll()).Returns(Task.FromResult(IpAddressesSeeder.GetIpAddressesMock()));
            _getIpAddressCommand.Execute(null);
            var ipAddress = _viewModel.IpAddresses;

            Assert.That(ipAddress.Count, Is.EqualTo(5));
        }      
    }
}
