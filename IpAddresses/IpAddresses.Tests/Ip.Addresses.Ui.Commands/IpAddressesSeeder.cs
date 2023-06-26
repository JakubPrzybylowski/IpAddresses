using IpAddresses.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddresses.Tests.Ip.Addresses.Ui.Commands
{
    public static  class IpAddressesSeeder
    {
        public static IEnumerable<IpAddress> GetIpAddressesMock()
        {
            var ipAddresses = new List<IpAddress>();
            for (int i = 0; i < 5; i++)
            {
                var ipAddress = new IpAddress()
                {
                    Ip = $"123.123.123.12{i}",
                };
                ipAddresses.Add(ipAddress);
            }

            return ipAddresses;
        }
    }
}
