using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using MediatR;

namespace AppTree.Application.Commands
{
    public class CreateApplicationDependencyCommand : IRequest<bool>
    {
        public int ParentApplicationId { get; set; }
        public int ApplicationId { get; }

        public CreateApplicationDependencyCommand(int parentApplicationId, int applicationId)
        {
            ParentApplicationId = parentApplicationId;
            ApplicationId = applicationId;
        }
    }
}
