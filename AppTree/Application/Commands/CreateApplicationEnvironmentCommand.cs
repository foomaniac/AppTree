using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using AppTree.Domain.AggregateModels.ApplicationAggregate;
using AppTree.Domain.AggregateModels.HostAggregate;
using MediatR;

namespace AppTree.Application.Commands
{
    public class CreateApplicationEnvironmentCommand : IRequest<bool>
    {
        public string EnvironmentName { get; set; }

        public int HostId { get; set; }

        public string Url { get; set; }

        public int ApplicationId { get; set; }

        public CreateApplicationEnvironmentCommand(string environmentName, int hostId, string url, int applicationId)
        {
            EnvironmentName = environmentName;
            HostId = hostId;
            Url = url;
            ApplicationId = applicationId;
        }
    }
}
