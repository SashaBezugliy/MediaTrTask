using MediatR;

namespace SF.API.Infrastructure.Users
{
    public class Query : IRequest<Command>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}