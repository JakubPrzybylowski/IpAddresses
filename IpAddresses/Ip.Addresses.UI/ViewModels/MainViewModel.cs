namespace Ip.Addresses.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public IPDetailsViewModel IPDetailsViewModel { get; set; }

        public MainViewModel()
        {
            IPDetailsViewModel = new IPDetailsViewModel();
        }
    }
}
