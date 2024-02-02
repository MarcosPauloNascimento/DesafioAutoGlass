using DesafioAutoGlass.Application.Dtos;
using DesafioAutoGlass.Application.Interfaces;
using DesafioAutoGlass.Domain.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace DesafioAutoGlass.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : MainController
    {
        private readonly IApplicationProductServices _applicationService;
        
        public ProductController(INotifier notifier, IApplicationProductServices applicationService) : base(notifier)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponseDto<ProductDto>>> Get([FromQuery] string? filter, 
            [FromQuery] int page = 1, 
            [FromQuery] int pageSize = 25)
        {
            if (page == -1) page = 1;

            var response = await _applicationService.GetAll(filter, page, pageSize);

            if (!response?.Result.Any() ?? false)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductDto>> Get(int id)
        {
            if (id <= 0)
            {
                Notify("Código Inválido");
                return CustomResponse();
            }

            var product = await _applicationService.GetById(id);

            if (product == null)
                return NotFound(string.Format(_messageNotFound, "produto"));

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDto>> Post([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _applicationService.Add(productDto);

            if (!ValidOperation())
                return CustomResponse();

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] ProductDto productDto)
        {
            if (id != productDto.Id)
            {
                Notify("Os códigos informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _applicationService.Update(productDto);

            if (!ValidOperation())
                return CustomResponse();

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (id <= 0)
            {
                Notify("Código Inválido");
                return CustomResponse();
            }

            var productDto = await _applicationService.GetById(id);

            if (productDto == null)
                return NotFound(string.Format(_messageNotFound, "produto"));

            await _applicationService.Delete(productDto);

            if (!ValidOperation())
                return CustomResponse();

            return NoContent();
        }
    }
}
