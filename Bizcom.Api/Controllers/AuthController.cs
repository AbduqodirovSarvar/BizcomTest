using Bizcom.Application.UseCases.Authorize.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace Bizcom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPost("Login")]
        public async Task<ExpandoObject> SignIn([FromBody] LoginCommand command)
        {
            dynamic obj = new ExpandoObject();
            obj.Token = await _mediator.Send(command);
            obj.Token = Ok();
            
            return obj;
        }
    }
}