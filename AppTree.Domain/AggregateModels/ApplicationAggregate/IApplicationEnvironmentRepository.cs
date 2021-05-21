using AppTree.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTree.Domain.AggregateModels.ApplicationAggregate
{
   public interface IApplicationEnvironmentRepository : IRepository<ApplicationEnvironment>
    {
        IEnumerable<ApplicationEnvironment> GetAll();
        ApplicationEnvironment Add(ApplicationEnvironment applicationEnvironment);
        void Update(ApplicationEnvironment applicationEnvironment);
        Task<ApplicationEnvironment> GetAsync(int applicationEnvironmentId);
    }
}
