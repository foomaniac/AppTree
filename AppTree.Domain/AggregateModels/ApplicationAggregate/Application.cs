using System;
using System.Collections.Generic;
using System.Text;

namespace AppTree.Domain.AggregateModels.ApplicationAggregate
{
    public class Application
    {
        public int? Id { get; set;}
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Repository { get; set; }
        public virtual ApplicationType ApplicationType { get; set; }
        public virtual ICollection<Dependency> Dependencies { get; set; }
    }
}
