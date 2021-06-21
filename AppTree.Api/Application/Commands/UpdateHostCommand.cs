using MediatR;

namespace AppTree.Api.Application.Commands
{
    public class UpdateHostCommand : IRequest<bool>
    {
        public int Id { get; }
        public string HostName { get; private set; }
        public string Domain { get; private set; }

        public string Location { get; private set; }
        public string Summary { get; private set; }

        public UpdateHostCommand(int id, string hostName, string domain, string location, string summary)
        {
            Id = id;
            HostName = hostName;
            Summary = summary;
            Location = location;
            Domain = domain;
        }
    }
}
