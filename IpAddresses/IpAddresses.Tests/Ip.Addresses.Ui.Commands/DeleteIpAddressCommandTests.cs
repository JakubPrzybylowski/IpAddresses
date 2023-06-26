
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
    public class DeleteIpAddressCommandTests
    {
        private IPDetailsViewModel _viewModel;
        private Mock<IIpAddressService> _ipAddressService;
        private IPDetailMapper _mapper;
        private ICommand _deleteIpAddressCommand;
        private Mock<IDialogService> _dialogService;

        [SetUp]
        public void SetUp()
        {
            _ipAddressService = new Mock<IIpAddressService>();
            _viewModel = new IPDetailsViewModel();
            _mapper = new IPDetailMapper();
            _dialogService = new Mock<IDialogService>();
            _deleteIpAddressCommand = new DeleteIpAddressCommand(_viewModel, _mapper, _ipAddressService.Object, _dialogService.Object);
        }

        [Test]
        public void AfterDeleteCommand_CollectionIpAddresses_ShoulHave_OneObjectLess()
        {
            _dialogService.Setup(p => p.ShowMessageBox(It.IsAny<string>()));
            _viewModel.IpAddresses = new ObservableCollection<IpAddressDto>(_mapper.Map(IpAddressesSeeder.GetIpAddressesMock().ToList()));
            _viewModel.SelectedIpAddress = _viewModel.IpAddresses[0];
            _ipAddressService.Setup(p => p.Get(It.IsAny<string>())).Returns(Task.FromResult(new IpAddress() { Ip = "123.123..123.120" }));
            _ipAddressService.Setup(p => p.Delete(It.IsAny<IpAddress>())).Returns(Task.FromResult(true));           
            _deleteIpAddressCommand.Execute(null);

            Assert.That(_viewModel.IpAddresses.Count, Is.EqualTo(4));
        }

    }
}
