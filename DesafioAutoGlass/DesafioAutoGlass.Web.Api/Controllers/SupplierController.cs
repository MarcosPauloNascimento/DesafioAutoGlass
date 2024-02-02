using DesafioAutoGlass.Application.Dtos;
using DesafioAutoGlass.Application.Interfaces;
using DesafioAutoGlass.Domain.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;


namespace DesafioAutoGlass.Web.Api.Controllers
{
    [Route("api/[controller]")]
    public class SupplierController : MainController
    {
        private readonly IApplicationSupplierServices _applicationService;

        public SupplierController(INotifier notifier, IApplicationSupplierServices applicationService) : base(notifier)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> Get()
        {
            var supplierList = await _applicationService.GetAll();

            if (!supplierList?.Any() ?? false)
                return NotFound();

            return Ok(supplierList);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<SupplierDto>> Get(int id)
        {
            if (id <= 0)
            {
                Notify("Código Inválido");
                return CustomResponse();
            }

            var supplier = await _applicationService.GetById(id);

            if (supplier == null)
                return NotFound(string.Format(_messageNotFound, "fornecedor"));

            return Ok(supplier);
        }

        [HttpGet("{id:int}/products")]
        public async Task<ActionResult<ProductDto>> GetProducts(int id)
        {
            if (id <= 0)
            {
                Notify("Código Inválido");
                return CustomResponse();
            }

            var supplier = await _applicationService.GetProductsBySuplierId(id);

            if (supplier == null)
                return NotFound(string.Format(_messageNotFound, "fornecedor"));

            return Ok(supplier);
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDto>> Post([FromBody] SupplierDto supplierDto)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _applicationService.Add(supplierDto);

            if (!ValidOperation())
                return CustomResponse();

            return Ok();
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] SupplierDto supplierDto)
        {
            if (id != supplierDto.Id)
            {
                Notify("Os códigos informados não são iguais!");
                return CustomResponse();
            }

            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            await _applicationService.Update(supplierDto);

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

            var supplierDto = await _applicationService.GetById(id);

            if (supplierDto == null)
                return NotFound(string.Format(_messageNotFound, "fornecedor"));

            await _applicationService.Delete(supplierDto);

            if (!ValidOperation())
                return CustomResponse();

            return NoContent();
        }
    }
}
