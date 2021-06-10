using AppTree.Domain.AggregateModels.ApplicationAggregate;
using System;
using System.Collections.Generic;

namespace AppTree.Domain.AggregateModels.HostAggregate
{
    public class Host
    {
        public int? Id { get; }
        public string HostName { get; private set; }
        public string Domain { get; private set; }

        /// <summary>
        /// Azure
        /// OnPrem
        /// </summary>
        public string Location { get; private set; }
        public string Summary { get; private set; }

        public ICollection<ApplicationEnvironment> Applications { get; }

        public Host()
        {
            Applications = new List<ApplicationEnvironment>();
        }

        public void UpdateHost(string hostName, string domain, string location, string summary)
        {
            HostName = hostName;
            Domain = domain;
            Location = location;
            Summary = summary;
        }
    }
}
