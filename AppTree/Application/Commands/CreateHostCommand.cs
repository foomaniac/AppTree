using MediatR;

namespace AppTree.Application.Commands
{
    public class CreateHostCommand : IRequest<bool>
    {
        public string HostName { get; private set; }
        public string Domain { get; private set; }
        public string Location { get; private set; }
        public string Summary { get; private set; }

        public CreateHostCommand(string hostName, string domain, string location, string summary)
        {
            HostName = hostName;
            Summary = summary;
            Location = location;
            Domain = domain;
        }
    }
}
