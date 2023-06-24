using Ip.Addresses.UI.ViewModels;
using Ip.Addresses.UI.ViewModels.Mappers;
using IpAddresses.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ip.Addresses.UI.Commands
{
    internal class GetIpAddressCommand : CommandBase
    {
        private IPDetailsViewModel _viewModel;
        private IIpAddressService _ipAddressService;
        private IPDetailMapper _mapper;

        public GetIpAddressCommand(IPDetailsViewModel viewModel, IPDetailMapper mapper, IIpAddressService service)
        {
            _viewModel = viewModel;
            _ipAddressService = service;
            _mapper = mapper;
        }
        public override async void Execute(object parameter)
        {
            var ipAddresses = await _ipAddressService.GetAll();
            _viewModel.IpAddresses = new System.Collections.ObjectModel.ObservableCollection<IpAddresses.Domain.Models.IpAddress>(ipAddresses);
        }
    }
}
