using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddresses.EF
{
    public class IpAddressContextFactory : IDesignTimeDbContextFactory<IpAddressDBContext>
    {
        public IpAddressDBContext CreateDbContext(string[] args)
        {
            var options = new DbContextOptionsBuilder<IpAddressDBContext>();
            options.UseSqlServer("Server=.; Database=IpAddressesDB; Trusted_Connection=True");
            return new IpAddressDBContext(options.Options);
        }
    }
}
