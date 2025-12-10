using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerceEAV.Application.Features.ProductAttributes.Commands;
using ECommerceEAV.Application.Features.ProductAttributes.Queries;

namespace ECommerceEAV.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductAttributesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductAttributesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductAttributesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductAttributeByIdQuery { Id = id });
            if (result.Data == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductAttributeCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductAttributeCommand command)
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
            var result = await _mediator.Send(new DeleteProductAttributeCommand { Id = id });
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
    }
}



