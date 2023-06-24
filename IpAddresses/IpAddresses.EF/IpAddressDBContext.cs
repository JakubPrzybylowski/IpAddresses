using IpAddresses.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddresses.EF
{
    public class IpAddressDBContext : DbContext
    {
        public DbSet<IpAddress> IpAddresses { get; set; }

        public IpAddressDBContext()
        {

        }

        public IpAddressDBContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IpAddress>().HasKey(x => x.Id);
        }
    }
}
