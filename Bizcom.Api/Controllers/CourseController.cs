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
        [HttpGet("Courses/AverageScoreMax")]
        public async Task<IActionResult> GetCourseMaxAverageScore(GetStudentCourseWhichAverageScoreMaxQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("Course/MaxScore")]
        public async Task<IActionResult> GetCourseMaxScore(GetStudentCourseWhichGetMaxScoreQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("Course/10StudentScoreOver80")]
        public async Task<IActionResult> GetCourse10StudentScoreOver80(GetTeacherCoursewhichNstudentAndOverMScoreQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [Authorize("TeacherActions")]
        [HttpGet("AllCourseForTeacher")]
        public async Task<IActionResult> GetAllCurrentTeacher(GetAllCourseForTeacherQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}
