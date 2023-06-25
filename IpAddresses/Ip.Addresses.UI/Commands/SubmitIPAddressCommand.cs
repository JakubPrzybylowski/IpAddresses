using Ip.Addresses.UI.Mappers;
using Ip.Addresses.UI.ViewModels;
using IpAddresses.EF.Services;
using System;
using System.Windows;

namespace Ip.Addresses.UI.Commands
{
    public class SubmitIpAddressCommand : CommandBase
    {
        private readonly IPDetailsViewModel _viewModel;
        private readonly IIpAddressService _ipAddressService;
        private readonly IPDetailMapper _mapper;

        public SubmitIpAddressCommand(IPDetailsViewModel viewModel, IPDetailMapper mapper, IIpAddressService service)
        {
            _viewModel = viewModel;
            _ipAddressService = service;
            _mapper = mapper;
        }
        public async override void Execute(object parameter)
        {
            try
            {
                var ipAddress = await _ipAddressService.Create(_viewModel.IPAddressInput);
                if (ipAddress == null)
                {
                    MessageBox.Show($"Cound not find IpAddress with Ip: {_viewModel.IPAddressInput}");
                    return;
                }
                _viewModel.IpAddresses.Add(_mapper.Map(ipAddress));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
