using Ip.Addresses.UI.ViewModels;
using Ip.Addresses.UI.ViewModels.Mappers;
using IpAddresses.Domain.Services;
using IpAddresses.EF.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Ip.Addresses.UI.Commands
{
    public class SubmitIPAddressCommand : CommandBase
    {
        private IPDetailsViewModel _viewModel;  
        private  IIpAddressService _ipAddressService;
        private IPDetailMapper _mapper;

        public SubmitIPAddressCommand(IPDetailsViewModel viewModel, IPDetailMapper mapper, IIpAddressService service)
        {
            _viewModel = viewModel;
            _ipAddressService = service;
            _mapper = mapper;
        }
        public async override void Execute(object parameter)
        {
            await _ipAddressService.Create(_viewModel.IPAddressInput);
        }
    }
}
