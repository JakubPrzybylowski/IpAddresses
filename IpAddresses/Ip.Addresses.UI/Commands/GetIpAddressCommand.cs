using Ip.Addresses.UI.Mappers;
using Ip.Addresses.UI.Models;
using Ip.Addresses.UI.ViewModels;
using IpAddresses.EF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Ip.Addresses.UI.Commands
{
    internal class GetIpAddressCommand : CommandBase
    {
        private readonly IPDetailsViewModel _viewModel;
        private readonly IIpAddressService _ipAddressService;
        private readonly IPDetailMapper _mapper;

        public GetIpAddressCommand(IPDetailsViewModel viewModel, IPDetailMapper mapper, IIpAddressService service)
        {
            _viewModel = viewModel;
            _ipAddressService = service;
            _mapper = mapper;
        }
        public override async void Execute(object parameter)
        {
            try
            {
                var ipAddresses = await _ipAddressService.GetAll();
                var ipAddressesDto = _mapper.Map(ipAddresses.ToList());
                _viewModel.IpAddresses = new System.Collections.ObjectModel.ObservableCollection<IpAddressDto>(ipAddressesDto);
            }
            catch(Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            }
            
        }
    }
}
