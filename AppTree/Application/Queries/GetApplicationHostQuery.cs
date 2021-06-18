using MediatR;

namespace AppTree.Application.Queries
{
    public class GetApplicationHostQuery : IRequest<Domain.AggregateModels.HostAggregate.Host>
    {
        public int HostId { get; private set; }

        public GetApplicationHostQuery(int hostId)
        {
            this.HostId = hostId;
        }
    }
}
