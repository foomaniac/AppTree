using AppTree.Domain.AggregateModels.HostAggregate;

namespace AppTree.Domain.AggregateModels.ApplicationAggregate
{
    public class ApplicationEnvironment
    {
        public int Id { get; set; }
        public string EnvironmentName { get; set; }

        public int HostId { get; set; }
        public Host Host { get; set; }

        public string Url { get; set; }

        public int ApplicationId { get; set; }
        public Application ParentApplication { get; set; }

        public ApplicationEnvironment(string environmentName, int hostId, string url, int applicationId)
        {
            EnvironmentName = environmentName;
            HostId = hostId;
            Url = url;
            ApplicationId = applicationId;
        }
    }
}
