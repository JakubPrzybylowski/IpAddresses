using IpAddresses.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddresses.EF.Services
{
    public interface  IIpAddressService
    {
        Task<IEnumerable<IpAddress>> GetAll();
        Task<IpAddress> Get(string id);
        Task<IpAddress> Create(string ip);
        Task<IpAddress> Update(IpAddress entity);
        Task<bool> Delete(IpAddress entity);
    }
}
