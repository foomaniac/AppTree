using AppTree.Domain.Seedwork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppTree.Domain.AggregateModels.HostAggregate
{
    public interface IHostRepository : IRepository<Host>
    {
        IEnumerable<Host> GetAll();
        Host Add(Host host);
        void Update(Host host);
        Task<Host> GetAsync(int id);
    }
}
