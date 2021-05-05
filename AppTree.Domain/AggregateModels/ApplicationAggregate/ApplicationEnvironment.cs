using System;
using System.Collections.Generic;
using System.Text;

namespace AppTree.Domain.AggregateModels.ApplicationAggregate
{
    public class ApplicationEnvironment
    {
        public int Id { get; set; }
        public string EnvironmentName { get; set; }
        public string Host { get; set; }
        public string Url { get; set; }

    }
}
