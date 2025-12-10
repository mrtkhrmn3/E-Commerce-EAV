using MediatR;
using Microsoft.AspNetCore.Mvc;
using ECommerceEAV.Application.Features.ProductAttributeValues.Commands;
using ECommerceEAV.Application.Features.ProductAttributeValues.Queries;

namespace ECommerceEAV.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductAttributeValuesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductAttributeValuesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllProductAttributeValuesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetProductAttributeValueByIdQuery { Id = id });
            if (result.Data == null)
                return NotFound(result);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateProductAttributeValueCommand command)
        {
            var result = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateProductAttributeValueCommand command)
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
            var result = await _mediator.Send(new DeleteProductAttributeValueCommand { Id = id });
            if (!result.Success)
                return NotFound(result);
            return Ok(result);
        }
    }
}



