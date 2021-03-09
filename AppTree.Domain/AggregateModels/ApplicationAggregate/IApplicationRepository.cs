using AppTree.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTree.Domain.AggregateModels.ApplicationAggregate
{
   public interface IApplicationRepository : IRepository<Application>
    {
        IEnumerable<Application> GetAll();
        Application Add(Application application);
        void Update(Application application);
        Task<Application> GetAsync(int applicationId);
    }
}
