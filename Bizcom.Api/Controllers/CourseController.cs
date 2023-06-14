using Bizcom.Application.UseCases.Courses.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bizcom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("AverageScoreMax")]
        public async Task<IActionResult> GetCourseMaxAverageScore()
        {
            return Ok(await _mediator.Send(new GetStudentCourseWhichAverageScoreMaxQuery()));
        }

        [HttpGet("MaxScore")]
        public async Task<IActionResult> GetCourseMaxScore()
        {
            return Ok(await _mediator.Send(new GetStudentCourseWhichGetMaxScoreQuery()));
        }

        [HttpGet("10StudentScoreOver80")]
        public async Task<IActionResult> GetCourse10StudentScoreOver80()
        {
            return Ok(await _mediator.Send(new GetTeacherCoursewhichNstudentAndOverMScoreQuery()));
        }

/*        [Authorize("TeacherActions")]*/
        [HttpGet("AllCourseForTeacher")]
        public async Task<IActionResult> GetAllCurrentTeacher()
        {
            return Ok(await _mediator.Send(new GetAllCourseForTeacherQuery()));
        }
    }
}
