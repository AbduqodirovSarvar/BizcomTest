using Bizcom.Application.UseCases.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bizcom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllUserBeelineNum")]
        public async Task<IActionResult> GetAllBeeline()
        {
            return Ok(await _mediator.Send(new GetAllUserWithBeelineQuery()));
        }
    }
}
