using Bizcom.Application.UseCases.Admins.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bizcom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "AdminActions")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("AddStudent")]
        public async Task<IActionResult> CreateStudent(AddStudentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("AddTeacher")]
        public async Task<IActionResult> CreateTeacher(AddTeacherCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("AddCourse")]
        public async Task<IActionResult> CreateCourse(AddCourseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPost("AddStudentToCourse")]
        public async Task<IActionResult> AddStudentCourse(AddStudentToCourseCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
