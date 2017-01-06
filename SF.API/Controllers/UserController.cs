using System;
using System.Web.Http;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SF.API.ExceptionHandling;
using SF.API.Infrastructure.Users;

namespace SF.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [Route("Get")]
        public IHttpActionResult Get(string userName, string password)
        {
            //This will be read from the access token claims.
            var userId = User.Identity.Name;
            var model = _mediator.Send(new Query {UserName = userName, Password = password});
            
            if (model == null)
                return NotFound();

            return Ok(model);
        }


        // POST api/User/Register
        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(Command command)
        {
            //This will be read from the access token claims.
            var userId = User.Identity.Name;
            _mediator.Send(command);

            return Ok();
        }
    }
}