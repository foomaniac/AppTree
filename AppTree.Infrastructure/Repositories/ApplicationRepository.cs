using AppTree.Domain.AggregateModels.ApplicationAggregate;
using AppTree.Domain.Seedwork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTree.Infrastructure.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private AppTreeContext _context;

        public ApplicationRepository(AppTreeContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }

        public Application Add(Application application)
        {
           return _context.Applications.Add(application).Entity;
        }

        public IEnumerable<Application> GetAll()
        {
            return _context.Applications;
        }

        public async Task<Application> GetAsync(int applicationId)
        {
            var application = await _context.Applications.FirstOrDefaultAsync(o => o.Id == applicationId);

            return application;
        }

        public void Update(Application application)
        {
            _context.Entry(application).State = EntityState.Modified;
        }
    }
}
