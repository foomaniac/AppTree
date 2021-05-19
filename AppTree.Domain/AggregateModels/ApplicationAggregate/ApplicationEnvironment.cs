﻿namespace AppTree.Domain.AggregateModels.ApplicationAggregate
{
    public class ApplicationEnvironment
    {
        public int Id { get; set; }
        public string EnvironmentName { get; set; }
        public string Host { get; set; }
        public string Url { get; set; }

        public int ApplicationId { get; set; }
        public Application ParentApplication { get; set; }
    }
}
