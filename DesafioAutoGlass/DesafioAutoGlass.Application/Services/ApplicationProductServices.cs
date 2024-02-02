using AutoMapper;
using DesafioAutoGlass.Application.Dtos;
using DesafioAutoGlass.Application.Interfaces;
using DesafioAutoGlass.Application.Validations;
using DesafioAutoGlass.Domain.Core.Interfaces.Services;
using DesafioAutoGlass.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioAutoGlass.Application.Services
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

        public async Task<bool> Add(ProductDto productDto)
        {
            try
            {
                var product = _mapper.Map<ProductDto, Product>(productDto);

                if (!ExecuteValidation(new ProductValidations(), product))
                    return false;

                await _productService.Add(product);
                return true;
            }
            catch (Exception e)
            {
                Notify($"Erro ao tentar adicionar o produto | {e.InnerException.Message}");
                return false;
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
                product.ChangeStatus();
                await _productService.Delete(product);
            }
            catch (Exception e)
            {
                Notify($"Erro ao tentar remover o produto | {e.InnerException.Message}");
            }
        }

        public async Task<PaginationResponseDto<ProductDto>> GetAll(string filter, int page, int pageSize)
        {
            var product = await _productService.GetAll(filter);

            var count = product.Count();

            product = product
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            var totalPages = (int)Math.Abs((double)count / pageSize) + count % pageSize;

            var productDto =  _mapper.Map<List<ProductDto>>(product);

            var response = new PaginationResponseDto<ProductDto>(page,
                    count,
                    pageSize,
                    totalPages == 0 ? 1 : totalPages,
                    productDto);

            return response;
        }

        public async Task<ProductDto> GetById(int id)
        {
            var product = await _productService.Get(id);
            return _mapper.Map<ProductDto>(product);
        }
    }
}
