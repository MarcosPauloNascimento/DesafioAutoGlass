using AutoMapper;
using DesafioAutoGlass.Application.AutoMapperProfile;
using DesafioAutoGlass.Application.Dtos;
using DesafioAutoGlass.Application.Services;
using DesafioAutoGlass.Domain.Core.Interfaces.Services;
using Moq;
using Xunit;

namespace DesafioAutoGlass.Tests.Service
{
    public class ProductServiceTest
    {
        private ApplicationProductServices _services;
        private readonly IMapper _mapper;

        public ProductServiceTest()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ProductProfile());
            }).CreateMapper();

            _mapper = config;

            _services = new ApplicationProductServices(_mapper,
                new Mock<IProductService>().Object,
                new Mock<INotifier>().Object);
        }

        #region Test Add Product

        [Fact]
        public void AddProductSuccess()
        {
            var product = new ProductDto
            {
                Description = "Oleo 2 tempos",
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddYears(-2),
                ExpirationDate = DateTime.UtcNow.AddYears(2)
            };

            var result = _services.Add(product);

            Assert.True(result.Result);
        }

        [Fact]
        public void AddProductFail_Description_Empty()
        {
            var product = new ProductDto
            {
                Description = "",
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddYears(-2),
                ExpirationDate = DateTime.UtcNow.AddYears(2)
            };

            var result = _services.Add(product);

            Assert.False(result.Result);
        }

        [Fact]
        public void AddProductFail_Description_Null()
        {
            var product = new ProductDto
            {
                Description = null,
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddYears(-2),
                ExpirationDate = DateTime.UtcNow.AddYears(2)
            };

            var result = _services.Add(product);

            Assert.False(result.Result);
        }

        [Fact]
        public void AddProductFail_Description_Less_Than_2_Characters()
        {
            var product = new ProductDto
            {
                Description = "a",
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddYears(-2),
                ExpirationDate = DateTime.UtcNow.AddYears(2)
            };

            var result = _services.Add(product);

            Assert.False(result.Result);
        }

        [Fact]
        public void AddProductFail_ManufacturingDate_Greater_Than_Today()
        {
            var product = new ProductDto
            {
                Description = "Amortecedor",
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddDays(1),
                ExpirationDate = DateTime.UtcNow.AddYears(2)
            };

            var result = _services.Add(product);

            Assert.False(result.Result);
        }

        [Fact]
        public void AddProductFail_ExpirationDate_Less_Than_ManufacturingDate()
        {
            var product = new ProductDto
            {
                Description = "Amortecedor",
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddYears(-1),
                ExpirationDate = DateTime.UtcNow.AddYears(-2)
            };

            var result = _services.Add(product);

            Assert.False(result.Result);
        }

        #endregion

        #region Test Update Product

        [Fact]
        public void UpdateAddProductSuccess()
        {
            var product = new ProductDto
            {
                Description = "Oleo 2 tempos",
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddYears(-2),
                ExpirationDate = DateTime.UtcNow.AddYears(2)
            };

            var result = _services.Update(product);

            Assert.True(result.Result);
        }

        [Fact]
        public void UpdateProductFail_Description_Empty()
        {
            var product = new ProductDto
            {
                Description = "",
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddYears(-2),
                ExpirationDate = DateTime.UtcNow.AddYears(2)
            };

            var result = _services.Update(product);

            Assert.False(result.Result);
        }

        [Fact]
        public void UpdateProductFail_Description_Null()
        {
            var product = new ProductDto
            {
                Description = null,
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddYears(-2),
                ExpirationDate = DateTime.UtcNow.AddYears(2)
            };

            var result = _services.Update(product);

            Assert.False(result.Result);
        }

        [Fact]
        public void UpdateProductFail_Description_Less_Than_2_Characters()
        {
            var product = new ProductDto
            {
                Description = "a",
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddYears(-2),
                ExpirationDate = DateTime.UtcNow.AddYears(2)
            };

            var result = _services.Update(product);

            Assert.False(result.Result);
        }

        [Fact]
        public void UpdateProductFail_ManufacturingDate_Greater_Than_Today()
        {
            var product = new ProductDto
            {
                Description = "Amortecedor",
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddDays(1),
                ExpirationDate = DateTime.UtcNow.AddYears(2)
            };

            var result = _services.Update(product);

            Assert.False(result.Result);
        }

        [Fact]
        public void UpdateProductFail_ExpirationDate_Less_Than_ManufacturingDate()
        {
            var product = new ProductDto
            {
                Description = "Amortecedor",
                Status = true,
                ManufacturingDate = DateTime.UtcNow.AddYears(-1),
                ExpirationDate = DateTime.UtcNow.AddYears(-2)
            };

            var result = _services.Update(product);

            Assert.False(result.Result);
        }

        #endregion
                
    }
}
