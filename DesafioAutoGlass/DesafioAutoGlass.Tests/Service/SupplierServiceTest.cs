using AutoMapper;
using DesafioAutoGlass.Application.AutoMapperProfile;
using DesafioAutoGlass.Application.Dtos;
using DesafioAutoGlass.Application.Services;
using DesafioAutoGlass.Domain.Core.Interfaces.Services;
using Moq;
using Xunit;

namespace DesafioAutoGlass.Tests.Service
{
    public class SupplierServiceTest
    {
        private ApplicationSupplierServices _services;
        private readonly IMapper _mapper;

        public SupplierServiceTest()
        {
            var config = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new SupplierProfile());
            }).CreateMapper();

            _mapper = config;

            _services = new ApplicationSupplierServices(_mapper,
                new Mock<ISupplierService>().Object,
                new Mock<INotifier>().Object,
                new Mock<IProductService>().Object);
        }

        #region Test Add Supplier

        [Fact]
        public void AddSupplierSuccess()
        {
            var suplier = new SupplierDto
            {
                Description = "Joaozinho",
                CNPJ = "25669302000188",                
            };

            var result = _services.Add(suplier);

            Assert.True(result.Result);
        }

        [Fact]
        public void AddSupplierFail_Description_Empty()
        {
            var suplier = new SupplierDto
            {
                Description = "",
                CNPJ = "25669302000188",
            };

            var result = _services.Add(suplier);

            Assert.False(result.Result);
        }

        [Fact]
        public void AddSupplierFail_Description_Null()
        {
            var suplier = new SupplierDto
            {
                Description = null,
                CNPJ = "25669302000188",
            };

            var result = _services.Add(suplier);

            Assert.False(result.Result);
        }

        [Fact]
        public void AddSupplierFail_Description_Less_Than_2_Characters()
        {
            var suplier = new SupplierDto
            {
                Description = "J",
                CNPJ = "25669302000188",
            };

            var result = _services.Add(suplier);

            Assert.False(result.Result);
        }

        [Fact]
        public void AddSupplierFail_CNPJ_Empty()
        {
            var suplier = new SupplierDto
            {
                Description = "Auto Peças da Maria",
                CNPJ = "",
            };

            var result = _services.Add(suplier);

            Assert.False(result.Result);
        }

        [Fact]
        public void AddSupplierFail_CNPJ_Null()
        {
            var suplier = new SupplierDto
            {
                Description = "Auto Peças da Maria",
                CNPJ = null,
            };

            var result = _services.Add(suplier);

            Assert.False(result.Result);
        }

        [Fact]
        public void AddSupplierFail_CNPJ_Less_Than_14_Characters()
        {
            var suplier = new SupplierDto
            {
                Description = "Auto Peças da Maria",
                CNPJ = "2566930200018",
            };

            var result = _services.Add(suplier);

            Assert.False(result.Result);
        }

        #endregion

        #region Test Update Supplier

        [Fact]
        public void UpdateSupplierSuccess()
        {
            var suplier = new SupplierDto
            {
                Description = "Joaozinho",
                CNPJ = "25669302000188",
            };

            var result = _services.Update(suplier);

            Assert.True(result.Result);
        }

        [Fact]
        public void UpdateSupplierFail_Description_Empty()
        {
            var suplier = new SupplierDto
            {
                Description = "",
                CNPJ = "25669302000188",
            };

            var result = _services.Update(suplier);

            Assert.False(result.Result);
        }

        [Fact]
        public void UpdateSupplierFail_Description_Null()
        {
            var suplier = new SupplierDto
            {
                Description = null,
                CNPJ = "25669302000188",
            };

            var result = _services.Update(suplier);

            Assert.False(result.Result);
        }

        [Fact]
        public void UpdateSupplierFail_Description_Less_Than_2_Characters()
        {
            var suplier = new SupplierDto
            {
                Description = "J",
                CNPJ = "25669302000188",
            };

            var result = _services.Add(suplier);

            Assert.False(result.Result);
        }

        [Fact]
        public void UpdateSupplierFail_CNPJ_Empty()
        {
            var suplier = new SupplierDto
            {
                Description = "Auto Peças da Maria",
                CNPJ = "",
            };

            var result = _services.Update(suplier);

            Assert.False(result.Result);
        }

        [Fact]
        public void UpdateSupplierFail_CNPJ_Null()
        {
            var suplier = new SupplierDto
            {
                Description = "Auto Peças da Maria",
                CNPJ = null,
            };

            var result = _services.Update(suplier);

            Assert.False(result.Result);
        }

        [Fact]
        public void UpdateSupplierFail_CNPJ_Less_Than_14_Characters()
        {
            var suplier = new SupplierDto
            {
                Description = "Auto Peças da Maria",
                CNPJ = "2566930200018",
            };

            var result = _services.Update(suplier);

            Assert.False(result.Result);
        }

        #endregion

    }
}
