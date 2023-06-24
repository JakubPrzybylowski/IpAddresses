using IpAddresses.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpStackService
{
    public interface IIpStackService
    {
        Task<IpAddress> GetIpAddress(string ipAddress);
    }
}
