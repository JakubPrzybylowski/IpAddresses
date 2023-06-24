using IpAddresses.Domain.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IpStackService
{
    public class IpStackService : IIpStackService
    {
        public IpStackService()
        {

        }
        public async Task<IpAddress?> GetIpAddress(string ipAddress)
        {
            string accessKey = ConfigurationManager.AppSettings.Get("AccessKey"); ;

            string url = $"http://api.ipstack.com/{ipAddress}?access_key={accessKey}";

            try
            {
                using var client = new HttpClient();
                // Send the HTTP GET request
                HttpResponseMessage response = await client.GetAsync(url);

                // Check if the request was successful (status code 200)
                if (response.IsSuccessStatusCode)
                {
                    // Access and print the JSON response
                    string responseBody = await response.Content.ReadAsStringAsync();
                    var ipAddressObject = JsonConvert.DeserializeObject<IpAddress>(responseBody);
                    return ipAddressObject;

                }
                else
                {
                    throw new Exception($"Status Code:{response.StatusCode}, Error Message: {response.Content}");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
