using Bizcom.Application.UseCases.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bizcom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllStudentByName")]
        public async Task<IActionResult> GetAllStudentContainName(GetAllStudentsByNameContainQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("GetAllStudentFromDateToDate")]
        public async Task<IActionResult> GetAllStudentForDate(GetAllStudentsFromDateToDateQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("GetAllStudentToAge")]
        public async Task<IActionResult> GetAllStudentToAge(GetAllStudentToNYearsOldQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
