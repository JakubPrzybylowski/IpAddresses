using Ip.Addresses.UI.Commands;
using Ip.Addresses.UI.Mappers;
using Ip.Addresses.UI.Models;
using IpAddresses.Domain.Models;
using IpAddresses.EF.Services;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Ip.Addresses.UI.ViewModels
{

    public class IPDetailsViewModel : ViewModelBase
    {
        private ObservableCollection<IpAddressDto> _ipAddresses;
        private IPDetailMapper _mapper = new IPDetailMapper();
        private bool _isDeletebtnEnable;
        private IpAddressDto _SelectedIpAddress;
        private readonly IIpAddressService _ipAddressService;
        public IPDetailsViewModel()
        {
            _ipAddressService = new IpAddressService();
            _ipAddresses= new ObservableCollection<IpAddressDto>();
            SubmitIpAddressCommand = new SubmitIpAddressCommand(this, _mapper, _ipAddressService);
            GetIpAddressCommand = new GetIpAddressCommand(this, _mapper, _ipAddressService);      
            DeleteIpAddressCommand = new DeleteIpAddressCommand(this, _mapper, _ipAddressService);
            GetIpAddressCommand.Execute(this);
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

        public ICommand SubmitIpAddressCommand { get; }
        public ICommand GetIpAddressCommand { get; }
        public ICommand DeleteIpAddressCommand { get; }

        public IpAddressDto SelectedIpAddress
        { 
            get { return _SelectedIpAddress; }  
            set { 
                _SelectedIpAddress = value;
                if (value != null)
                {
                    DeleteBtnIsEnable = true;
                }
                else
                {
                    DeleteBtnIsEnable = false;
                }
                OnPropertyChanged(nameof(SelectedIpAddress)); }
        }

        public bool DeleteBtnIsEnable 
        { 
            get {  return _isDeletebtnEnable; }
            set { _isDeletebtnEnable = value; OnPropertyChanged(nameof(DeleteBtnIsEnable)); } 
        } 

        public ObservableCollection<IpAddressDto> IpAddresses
        {
            get => _ipAddresses;
            set 
            {
                _ipAddresses = value;
                this.OnPropertyChanged(nameof(IpAddresses));
            }
        }
    }
}
