using AutoMapper;
using DesafioAutoGlass.Application.Dtos;
using DesafioAutoGlass.Application.Interfaces;
using DesafioAutoGlass.Application.Validations;
using DesafioAutoGlass.Domain.Core.Interfaces.Services;
using DesafioAutoGlass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Application.Services
{
    public class ApplicationSupplierServices : ServiceBase, IApplicationSupplierServices
    {
        private readonly IMapper _mapper;
        private readonly ISupplierService _supplierService;
        private readonly IProductService _productService;

        public ApplicationSupplierServices(IMapper mapper, 
            ISupplierService supplierService, 
            INotifier notifier,
            IProductService productService)
            : base(notifier)
        {
            _mapper = mapper;
            _supplierService = supplierService;
            _productService = productService;
        }

        public async Task<bool> Add(SupplierDto supplierDto)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(supplierDto);

                if (!ExecuteValidation(new SupplierValidations(), supplier))
                    return false;

                await _supplierService.Add(supplier);
                return true;
            }
            catch (Exception e)
            {
                Notify($"Erro ao tentar adicionar o fornecedor | {e.InnerException.Message}");
                return false;
            }
        }

        public async Task<bool> Update(SupplierDto supplierDto)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(supplierDto);

                if (!ExecuteValidation(new SupplierValidations(), supplier))
                    return false;

                await _supplierService.Update(supplier);
                return true;
            }
            catch (Exception e)
            {
                Notify($"Erro ao tentar atualizar o fornecedor | {e.InnerException.Message}");
                return false;
            }
        }

        public async Task Delete(SupplierDto supplierDto)
        {
            try
            {
                var supplier = _mapper.Map<Supplier>(supplierDto);
                _supplierService.Detach(supplier);
                await _supplierService.Delete(supplier);
            }
            catch (Exception e)
            {
                Notify($"Erro ao tentar remover o fornecedor | {e.InnerException.Message}");
            }
        }

        public async Task<IEnumerable<SupplierDto>> GetAll()
        {
            var supplier = await _supplierService.GetAll();
            return _mapper.Map<IEnumerable<SupplierDto>>(supplier);
        }

        public async Task<SupplierDto> GetById(int id)
        {
            var supllier = await _supplierService.Get(id);
            return _mapper.Map<SupplierDto>(supllier);
        }

        public async Task<IEnumerable<ProductDto>> GetProductsBySuplierId(int id)
        {
            var products = await _productService.GetProductsBySupplierId(id);
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }
    }
}
