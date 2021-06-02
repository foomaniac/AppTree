using AppTree.Domain.Seedwork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppTree.Domain.AggregateModels.ApplicationAggregate
{
   public interface IApplicationDependencyRepository : IRepository<Dependency>
    {
        IEnumerable<Dependency> GetAll();
        Dependency Add(Dependency dependency);
        void Update(Dependency dependency);
        Task<Dependency> GetAsync(int parentApplicationId);
    }
}
