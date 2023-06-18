using Bizcom.Application.UseCases.Authorize.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var jwtToken = jwtTokenHandler.ReadJwtToken(obj.Token.ToString());
            var roleClaim = jwtToken.Claims[3];
            if(roleClaim != null)
            {
                obj.Role = roleClaim.Value;
            }
            obj.statusCode = 200;

            return obj;
        }
    }
}