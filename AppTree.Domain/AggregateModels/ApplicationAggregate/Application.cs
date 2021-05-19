using System;
using System.Collections.Generic;
using System.Text;

namespace AppTree.Domain.AggregateModels.ApplicationAggregate
{
    public class Application
    {
        public int? Id { get; }
        public string Name { get; private set; }
        public string Summary { get; private set; }
        public string Repository { get; private set; }
        public int ApplicationTypeId { get; private set; }
        public virtual ApplicationType ApplicationType { get; }
        public virtual ICollection<Dependency> Dependencies { get; }
        public virtual ICollection<ApplicationEnvironment> Environments { get; }

        public Application()
        {
            Dependencies = new List<Dependency>();
            Environments = new List<ApplicationEnvironment>();
        }

        public Application(string name, string summary, string repository, int applicationTypeId) : this()
        {
            Name = name;
            Summary = summary;
            Repository = repository;
            ApplicationTypeId = applicationTypeId;
        }

        public void UpdateApplication(string name, string summary, string repository, int applicationTypeId)
        {
            Name = name;
            Summary = summary;
            Repository = repository;
            ApplicationTypeId = applicationTypeId;
        }
        
    }
}
