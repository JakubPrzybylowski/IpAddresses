using Ip.Addresses.UI.Commands;
using Ip.Addresses.UI.ViewModels.Mappers;
using IpAddresses.Domain.Models;
using IpAddresses.EF.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Ip.Addresses.UI.ViewModels
{

    public class IPDetailsViewModel : ViewModelBase
    {
        public ObservableCollection<IpAddress> _ipAddresses;
        private IPDetailMapper _mapper = new IPDetailMapper();
        private readonly IpAddressService _ipAddressService;
        public IPDetailsViewModel()
        {
            _ipAddressService = new IpAddressService();
            SubmitIPAddressCommand = new SubmitIPAddressCommand(this, _mapper, _ipAddressService);
        }

        private string _ipAddressInput;
        public string IPAddressInput
        {
            get
            {
                return _ipAddressInput;
            }
            set
            {
                _ipAddressInput = value;
                OnPropertyChanged(nameof(IPAddressInput));
            }
        }

        public ICommand SubmitIPAddressCommand { get; }

        public ObservableCollection<IpAddress> IpAddresses
        {
            get => _ipAddresses;
            set 
            {
                _ipAddresses = value;
                OnPropertyChanged(nameof(IpAddresses));
            }
        }
    }
}
