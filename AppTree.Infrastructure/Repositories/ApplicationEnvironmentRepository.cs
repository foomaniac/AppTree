using AppTree.Domain.AggregateModels.ApplicationAggregate;
using AppTree.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTree.Infrastructure.Repositories
{
    public class ApplicationEnvironmentRepository : IApplicationEnvironmentRepository
    {
        private readonly AppTreeContext _context;

        public ApplicationEnvironmentRepository(AppTreeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public ApplicationEnvironment Add(ApplicationEnvironment applicationEnvironment)
        {
           return _context.ApplicationEnvironments.Add(applicationEnvironment).Entity;
        }

        public IEnumerable<ApplicationEnvironment> GetAll()
        {
            return _context.ApplicationEnvironments;
        }

        public async Task<ApplicationEnvironment> GetAsync(int applicationEnvironmentId)
        {
            var applicationEnvironment = await _context.ApplicationEnvironments.FirstOrDefaultAsync(o => o.Id == applicationEnvironmentId);

            return applicationEnvironment;
        }

        public void Update(ApplicationEnvironment applicationEnvironment)
        {
            _context.Entry(applicationEnvironment).State = EntityState.Modified;
        }
    }
}
