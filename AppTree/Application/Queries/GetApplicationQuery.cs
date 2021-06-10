using MediatR;

namespace AppTree.Application.Queries
{
    public class GetApplicationQuery : IRequest<Domain.AggregateModels.ApplicationAggregate.Application>
    {
        public int ApplicationId { get; set; }
    }
}
