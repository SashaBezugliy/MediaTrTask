using System;
using System.Web.Http;
using MediatR;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SF.API.ExceptionHandling;
using SF.API.Infrastructure.Users;

namespace SF.API.Controllers
{
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
            var model = _mediator.Send(new Query {UserName = userName, Password = password});

            try
            {
                Enum.Parse(typeof(ErrorMessages), "InController");
            }
            catch (Exception)
            {
                throw new InControllerException();
            }
            
            if (model == null)
                return NotFound();

            return Ok(model);
        }


        // POST api/User/Register
        [HttpPost]
        [Route("Register")]
        public IHttpActionResult Register(Command command)
        {
            _mediator.Send(command);

            return Ok();
        }
    }
}