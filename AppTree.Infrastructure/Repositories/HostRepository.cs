using AppTree.Domain.AggregateModels.HostAggregate;
using AppTree.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTree.Infrastructure.Repositories
{
    public class HostRepository : IHostRepository
    {
        private readonly AppTreeContext _context;

        public HostRepository(AppTreeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public Host Add(Host host)
        {
            return _context.Hosts.Add(host).Entity;
        }

        public IEnumerable<Host> GetAll()
        {
            return _context.Hosts;
        }

        public async Task<Host> GetAsync(int id)
        {
            return await _context.Hosts.FirstOrDefaultAsync(o => o.Id == id);

        }

        public void Update(Host host)
        {
            _context.Entry(host).State = EntityState.Modified;
        }
    }
}
