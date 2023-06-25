using Ip.Addresses.UI.Models;
using IpAddresses.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ip.Addresses.UI.Mappers
{
    public class IPDetailMapper : MapperBase<IpAddress, IpAddressDto>, IMapper<IpAddress, IpAddressDto>
    {
        public override IpAddress Map(IpAddressDto element)
        {
            return new IpAddress
            {
                Ip = element.Ip,
                Type = element.Type,
                ContinentCode = element.ContinentCode,
                ContinentName = element.ContinentName,
                CountryCode = element.CountryCode,
                CountryName = element.CountryName,
                RegionCode = element.RegionCode,
                RegionName = element.RegionName,
                City = element.City,
                Zip = element.Zip
            };
        }

        public override IpAddressDto Map(IpAddress element)
        {
            return new IpAddressDto
            {
                Ip = element.Ip,
                Type = element.Type,
                ContinentCode = element.ContinentCode,
                ContinentName = element.ContinentName,
                CountryCode = element.CountryCode,
                CountryName = element.CountryName,
                RegionCode = element.RegionCode,
                RegionName = element.RegionName,
                City = element.City,
                Zip = element.Zip
            };
        }
    }
}
