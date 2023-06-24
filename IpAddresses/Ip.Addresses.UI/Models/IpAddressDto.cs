using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ip.Addresses.UI.Models
{
    public class IpAddressDto : INotifyPropertyChanged
    {
        public string Ip { get; set; }
        public string Type { get; set; }
        public string ContinentCode { get; set; }
        public string ContinentName { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public string RegionCode { get; set; }
        public string RegionName { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
