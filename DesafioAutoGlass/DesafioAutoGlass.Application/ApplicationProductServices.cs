using AutoMapper;
using DesafioAutoGlass.Application.Dtos;
using DesafioAutoGlass.Application.Interfaces;
using DesafioAutoGlass.Application.Validations;
using DesafioAutoGlass.Domain.Core.Interfaces.Services;
using DesafioAutoGlass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Application
{
    public class ApplicationProductServices : ServiceBase, IApplicationProductServices
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ApplicationProductServices(IMapper mapper, IProductService productService, INotifier notifier)
            : base(notifier)
        {
            _mapper = mapper;
            _productService = productService;
        }

        public async Task<int?> Add(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);

                if (!ExecuteValidation(new ProductValidations(), product))
                    return null;

                await _productService.Add(product);
                return product.Id;
            }
            catch (Exception e)
            {
                Notify($"Erro ao tentar adicionar o produto | {e.InnerException.Message}");
                return null;
            }
        }

        public async Task<bool> Update(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);

                if (!ExecuteValidation(new ProductValidations(), product))
                    return false;

                await _productService.Update(product);
                return true;
            }
            catch (Exception e)
            {
                Notify($"Erro ao tentar atualizar o produto | {e.InnerException.Message}");
                return false;
            }
        }

        public async Task Delete(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<Product>(productDto);
                _productService.Detach(product);
                await _productService.Delete(product);
            }
            catch (Exception e)
            {
                Notify($"Erro ao tentar remover o produto | {e.InnerException.Message}");
            }
        }

        public async Task<IEnumerable<ProductDto>> GetAll()
        {
            var product = await _productService.GetAll();
            return _mapper.Map<IEnumerable<ProductDto>>(product);
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _productService.Get(id);
            return _mapper.Map<ProductDto>(product);
        }        
    }
}
