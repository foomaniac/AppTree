using AppTree.Domain.AggregateModels.ApplicationAggregate;
using AppTree.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTree.Infrastructure.Repositories
{
    public class ApplicationDependencyRepository : IApplicationDependencyRepository
    {
        private readonly AppTreeContext _context;

        public ApplicationDependencyRepository(AppTreeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public Dependency Add(Dependency dependency)
        {
           return _context.Dependencies.Add(dependency).Entity;
        }

        public IEnumerable<Dependency> GetAll()
        {
            return _context.Dependencies;
        }

        public async Task<Dependency> GetAsync(int parentApplicationId)
        {
            var dependency = await _context.Dependencies.FirstOrDefaultAsync(o => o.ParentApplicationId == parentApplicationId);

            return dependency;
        }

        public void Update(Dependency dependency)
        {
            _context.Entry(dependency).State = EntityState.Modified;
        }
    }
}
