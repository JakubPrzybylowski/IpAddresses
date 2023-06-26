using Ip.Addresses.UI.Commands;
using Ip.Addresses.UI.DialogServices;
using Ip.Addresses.UI.Mappers;
using Ip.Addresses.UI.Models;
using IpAddresses.Domain.Models;
using IpAddresses.EF;
using IpAddresses.EF.Services;
using System.Collections.ObjectModel;
using System.Windows.Data;
using System.Windows.Input;

namespace Ip.Addresses.UI.ViewModels
{

    public class IPDetailsViewModel : ViewModelBase
    {
        private ObservableCollection<IpAddressDto> _ipAddresses;
        private readonly IPDetailMapper _mapper;
        private bool _isDeletebtnEnable;
        private IpAddressDto _SelectedIpAddress;
        private readonly IIpAddressService _ipAddressService;
        private readonly IDialogService _dialogService;
        public IPDetailsViewModel()
        {
            _mapper = new IPDetailMapper();
            _ipAddressService = new IpAddressService(new IpStackService.IpStackService(), new GenericDataService<IpAddress>(new IpAddressContextFactory()));
            _ipAddresses= new ObservableCollection<IpAddressDto>();
            _dialogService= new DialogService();
            SubmitIpAddressCommand = new SubmitIpAddressCommand(this, _mapper, _ipAddressService, _dialogService);
            GetIpAddressCommand = new GetIpAddressCommand(this, _mapper, _ipAddressService, _dialogService);      
            DeleteIpAddressCommand = new DeleteIpAddressCommand(this, _mapper, _ipAddressService, _dialogService);
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
