using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using MediatR;

namespace AppTree.Application.Commands
{
    public class CreateApplicationCommand : IRequest<bool>
    {
        public string Name { get; }
        public string Summary { get;  }
        public string Repository { get; }
        public int ApplicationTypeId { get; }

        public CreateApplicationCommand(string name, string summary, string repository, int applicationTypeId)
        {
            Name = name;
            Summary = summary;
            Repository = repository;
            ApplicationTypeId = applicationTypeId;
        }
    }
}
