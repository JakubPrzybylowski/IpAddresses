using IpAddresses.Domain.Models;
using IpAddresses.Domain.Services;
using IpStackService;

namespace IpAddresses.EF.Services
{
    public class IpAddressService : IIpAddressService
    {
        private readonly IBaseDataService<IpAddress> _ipAddressService;
        private readonly IIpStackService _ipStackService;

        public IpAddressService()
        {

        }
        public IpAddressService(IIpStackService service, IBaseDataService<IpAddress> baseDataService)
        {
            _ipAddressService = baseDataService;
            _ipStackService = service;
        }

        public async Task<IpAddress?> Create(string ip)
        {
            try
            {
                if(ip == null || ip == "") 
                {
                    return null;
                }
                var ipAddress = await _ipStackService.GetIpAddress(ip);
                if (ipAddress == null || ipAddress.Ip == null)
                {
                    return null;
                }
                await _ipAddressService.Create(ipAddress);
                return ipAddress;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Delete(IpAddress entity)
        {
            try
            {
                return await _ipAddressService.Delete(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IpAddress> Get(string ip)
        {
            try
            {
                var ipAddresses = await GetAll();
                return ipAddresses.First(x => x.Ip == ip);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<IpAddress>> GetAll()
        {
            try
            {
                var ipAddresses = await _ipAddressService.GetAll();
                return ipAddresses;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Task<IpAddress> Update(IpAddress entity)
        {
           throw new NotImplementedException();
        }
    }
}
