using IpAddresses.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpAddresses.EF.Services
{
    public class GenericDataService<T> : IBaseDataService<T> where T : class
    {
        private readonly IpAddressContextFactory _contextFactory;
        public GenericDataService(IpAddressContextFactory contextFactory)
        {
            _contextFactory= contextFactory;
        }

        public async Task<T> Create(T entity)
        {
            using IpAddressDBContext context = _contextFactory.CreateDbContext();
            EntityEntry<T> createResult = await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
            return createResult.Entity;
        }

        public async Task<bool> Delete(T entity)
        {
            using IpAddressDBContext context = _contextFactory.CreateDbContext();
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<T> Get(int id)
        {
            using IpAddressDBContext context = _contextFactory.CreateDbContext();
            return await context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using IpAddressDBContext context = _contextFactory.CreateDbContext();
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            using IpAddressDBContext context = _contextFactory.CreateDbContext();
             context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }
    }
}
