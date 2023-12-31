﻿using Bizcom.Application.UseCases.Teachers.Commands;
using Bizcom.Application.UseCases.Teachers.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bizcom.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TeacherController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllTeacherOverAge")]
        public async Task<IActionResult> GetAllOverAge([FromQuery] GetAllTeachersOverNAgeQuery query)
        {
            return Ok(await _mediator.Send(query));
        }

        [HttpGet("GetTeacherStudentScoreOverN")]
        public async Task<IActionResult> GetForStudentOverN([FromQuery] GetTeachersForStudentsScoreOverNQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
        [Authorize("TeacherActions")]
        [HttpPatch("AddScoreForStudent")]
        public async Task<IActionResult> AddScore(AddStudentScoreCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet("All")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllTeacherQuery()));
        }
    }
}
