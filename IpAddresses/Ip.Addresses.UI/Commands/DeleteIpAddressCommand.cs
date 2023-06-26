using Ip.Addresses.UI.ViewModels;
using IpAddresses.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ip.Addresses.UI.Mappers;
using Ip.Addresses.UI.DialogServices;

namespace Ip.Addresses.UI.Commands
{
    public class DeleteIpAddressCommand : CommandBase
    {
        private readonly IPDetailsViewModel _viewModel;
        private readonly IIpAddressService _ipAddressService;
        private readonly IPDetailMapper _mapper;
        private readonly IDialogService _dialogService;

        public DeleteIpAddressCommand(IPDetailsViewModel viewModel, IPDetailMapper mapper, IIpAddressService service, IDialogService dialogService)
        {
            _viewModel = viewModel;
            _ipAddressService = service;
            _mapper = mapper;
            _dialogService = dialogService;
        }
        public override async void Execute(object parameter)
        {
            try
            {
                var ipAddress = await _ipAddressService.Get(_viewModel.SelectedIpAddress.Ip);

                var isDeleted = await _ipAddressService.Delete(ipAddress);
                if (!isDeleted)
                {
                    _dialogService.ShowMessageBox($"Could not delete IpAddress (Ip: {_viewModel.SelectedIpAddress.Ip}");
                }
                else
                {
                    _dialogService.ShowMessageBox($"IpAddress with Ip: {_viewModel.SelectedIpAddress.Ip} has been deleted");
                    _viewModel.IpAddresses.Remove(_viewModel.SelectedIpAddress);
                }
            }
            catch (Exception ex) 
            {
                _dialogService.ShowMessageBox(ex.Message );
            }
        }
    }
}
