using MediatR;

namespace AppTree.Application.Commands
{
    public class CreateHostCommand : IRequest<bool>
    {
        public string HostName { get; }
        public string Domain { get; }

        public string Location { get; }
        public string Summary { get; }

        public CreateHostCommand(string hostName, string domain, string location, string summary)
        {
            HostName = hostName;
            Summary = summary;
            Location = location;
            Domain = domain;
        }
    }
}
