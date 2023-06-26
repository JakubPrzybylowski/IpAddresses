using Ip.Addresses.UI.DialogServices;
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
        private readonly IDialogService _dialogService;

        public SubmitIpAddressCommand(IPDetailsViewModel viewModel, IPDetailMapper mapper, IIpAddressService service, IDialogService dialogService)
        {
            _viewModel = viewModel;
            _ipAddressService = service;
            _mapper = mapper;
            _dialogService = dialogService;
        }
        public async override void Execute(object parameter)
        {
            try
            {
                var ipAddress = await _ipAddressService.Create(_viewModel.IPAddressInput);
                if (ipAddress == null)
                {
                    _dialogService.ShowMessageBox($"Cound not find IpAddress with Ip: {_viewModel.IPAddressInput}");
                    return;
                }
                _viewModel.IpAddresses.Add(_mapper.Map(ipAddress));
            }
            catch (Exception ex)
            {
                _dialogService.ShowMessageBox(ex.Message);
            }
        }
    }
}
