using AppTree.Api.Models;
using MediatR;

namespace AppTree.Api.Application.Queries
{
    public class GetApplicationDetailsQuery : IRequest<Models.ApplicationModel>
    {
        public GetApplicationDetailsQuery(int applicationId)
        {
            ApplicationId = applicationId;
        }

        public int ApplicationId { get;  }
    }
}
