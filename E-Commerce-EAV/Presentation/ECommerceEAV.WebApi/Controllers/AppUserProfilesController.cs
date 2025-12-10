using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerceEAV.Application.Features.AppUserProfiles.Commands;
using ECommerceEAV.Application.Features.AppUserProfiles.Queries;

namespace ECommerceEAV.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppUserProfilesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppUserProfilesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllAppUserProfilesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetAppUserProfileByIdQuery { Id = id });
            if (result.Data == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppUserProfileCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateAppUserProfileCommand command)
        {
            if (id != command.Id)
                return BadRequest("ID mismatch");

            var result = await _mediator.Send(command);
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteAppUserProfileCommand { Id = id });
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
    }
}

