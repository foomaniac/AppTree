using System;
using System.Collections.Generic;
using System.Text;

namespace AppTree.Domain.AggregateModels.ApplicationAggregate
{
    public class Application
    {
        public int? Id { get; }
        public string Name { get; }
        public string Summary { get; }
        public string Repository { get; }
        public int ApplicationTypeId { get; }
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
        
    }
}
