using Ip.Addresses.UI.ViewModels;
using IpAddresses.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ip.Addresses.UI.Mappers;

namespace Ip.Addresses.UI.Commands
{
    class DeleteIpAddressCommand : CommandBase
    {
        private readonly IPDetailsViewModel _viewModel;
        private readonly IIpAddressService _ipAddressService;
        private readonly IPDetailMapper _mapper;

        public DeleteIpAddressCommand(IPDetailsViewModel viewModel, IPDetailMapper mapper, IIpAddressService service)
        {
            _viewModel = viewModel;
            _ipAddressService = service;
            _mapper = mapper;
        }
        public override async void Execute(object parameter)
        {
            try
            {
                var ipAddress = await _ipAddressService.Get(_viewModel.SelectedIpAddress.Ip);

                var isDeleted = await _ipAddressService.Delete(ipAddress);
                if (!isDeleted)
                {
                    MessageBox.Show($"Could not delete IpAddress (Ip: {_viewModel.SelectedIpAddress.Ip}");
                }
                else
                {
                    MessageBox.Show($"IpAddress with Ip: {_viewModel.SelectedIpAddress.Ip} has been deleted");
                    _viewModel.IpAddresses.Remove(_viewModel.SelectedIpAddress);
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message );
            }
        }
    }
}
