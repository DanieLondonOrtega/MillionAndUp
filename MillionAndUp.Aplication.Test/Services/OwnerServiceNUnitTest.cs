using System.Linq.Expressions;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using MillionAndUp.API.Mapper;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;
using MillionAndUp.Aplication.Services;
using MillionAndUp.Domain.Entities;
using MillionAndUp.Infrastructure.DataAccess.Repository;
using Moq;
using NUnit.Framework;


namespace MillionAndUp.Aplication.Test.Services
{
    [TestFixture]
    public class OwnerServiceNUnitTest
    {
        private MockRepository _mockRepository;
        private Mock<IRepositoryBase<Owner>> _ownerRepository;
        private IMapper _mapper;
        private Mock<IAzureBlobStorageService> _azureBlobStorageService;

        private static readonly OwnerDto _ownerDto = new() {
            IdOwner = Guid.Parse("39F86D2E-9F7B-47B3-BA6E-B9CB401228D2"),
            Name = "Prueba",
            Address = "Calle 17",            
            Birthday = DateTime.Parse("1993/03/28"),
        };

        private static readonly Owner _owner = new() {
            IdOwner = Guid.Parse("39F86D2E-9F7B-47B3-BA6E-B9CB401228D2"),            
            Name = "Prueba",
            Birthday = DateTime.Parse("1993/03/28"),
        };
        private static readonly List<Owner> _listOwner = new()
{
            _owner,
            new Owner() { IdOwner = Guid.NewGuid(), Name = "Prueba 2", Birthday = DateTime.Parse("1993/03/28") }
        };

        [SetUp]
        public void Setup()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new AutoMapping());
                });

                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }
            _mockRepository = new MockRepository(MockBehavior.Strict);
            _ownerRepository = _mockRepository.Create<IRepositoryBase<Owner>>();
            _azureBlobStorageService = _mockRepository.Create<IAzureBlobStorageService>();
        }

        public OwnerService CreateService()
        {
            return new OwnerService(
                _ownerRepository.Object,
                _mapper,
                _azureBlobStorageService.Object);
        }

        [Test]
        public async Task OwnerService_GetAll_ReturnsIEnumerableEntity_WhenExistData()
        {
            _ownerRepository.Setup(x => x.GetAll()).ReturnsAsync(_listOwner.AsQueryable());

            var service = CreateService();
            var result = await service.GetAll();
            Assert.IsTrue(CheckEqualsList(_listOwner, result.ToList()));
            _ownerRepository.VerifyAll();
        }

        [Test]
        public async Task OwnerService_GetById_ReturnsEntity_WhenIdExists()
        {
            Guid id = Guid.Parse("39F86D2E-9F7B-47B3-BA6E-B9CB401228D2");
            _ownerRepository.Setup(x => x.GetById(
                It.IsAny<Expression<Func<Owner, bool>>>(),
                It.IsAny<Expression<Func<Owner, object>>[]>())
                ).ReturnsAsync(_owner);

            var service = CreateService();
            var result = await service.Get(id);
            Assert.IsTrue(CheckEquals(_owner,result));
            _ownerRepository.VerifyAll();
        }

        [Test]
        public async Task OwnerService_GetById_ReturnsEntity_WhenIdNotExists()
        {
            Guid id = Guid.Parse("39F86D2E-9F7B-47B3-BA6E-B9CB401228D2");
            _ownerRepository.Setup(x => x.GetById(
                It.IsAny<Expression<Func<Owner, bool>>>(),
                It.IsAny<Expression<Func<Owner, object>>[]>())
                ).ReturnsAsync(Task.FromResult<Owner>(null).Result);

            var service = CreateService();
            var result = await service.Get(id);
            Assert.IsTrue(result is null);
            _ownerRepository.VerifyAll();
        }

        [Test]        
        public void OwnerService_Post_ReturnsTrue_WhenInsertData()
        {
            // Arrange
            _ownerRepository.Setup(x => x.Add(It.IsAny<Owner>())).Returns(true);
            var service = CreateService();
            OwnerDto entity = _ownerDto;

            // Act
            bool result = service.Post(entity);

            // Assert
            Assert.IsTrue(result);
            _ownerRepository.VerifyAll();
        }

        [Test]
        public void OwnerService_Post_ReturnsFalse_WhenNotInsertData()
        {
            // Arrange
            _ownerRepository.Setup(x => x.Add(It.IsAny<Owner>())).Returns(false);
            var service = CreateService();
            OwnerDto entity = _ownerDto;

            // Act
            bool result = service.Post(entity);

            // Assert
            Assert.IsFalse(result);
            _ownerRepository.VerifyAll();
        }

        [Test]
        public void OwnerService_Put_ReturnsTrue_WhenInsertData()
        {
            // Arrange
            _ownerRepository.Setup(x => x.Update(It.IsAny<Owner>())).Returns(true);
            var service = CreateService();
            OwnerDto entity = _ownerDto;

            // Act
            bool result = service.Put(entity);

            // Assert
            Assert.IsTrue(result);
            _ownerRepository.VerifyAll();
        }

        [Test]
        public void OwnerService_Put_ReturnsFalse_WhenNotInsertData()
        {
            // Arrange
            _ownerRepository.Setup(x => x.Update(It.IsAny<Owner>())).Returns(false);
            var service = CreateService();
            OwnerDto entity = _ownerDto;

            // Act
            bool result = service.Put(entity);

            // Assert
            Assert.IsFalse(result);
            _ownerRepository.VerifyAll();
        }              

        private bool CheckEquals(Owner a, OwnerDto b)
        {
            return a.IdOwner == b.IdOwner &&
                a.Name == b.Name &&
                a.Birthday == b.Birthday;
        }

        private bool CheckEqualsList(List<Owner> a, List<OwnerDto> b)
        {
            for (int i = 0; i < a.Count(); i++)
            {
                if (a[i].IdOwner != b[i].IdOwner ||
                    a[i].Name != b[i].Name ||
                    a[i].Birthday != b[i].Birthday)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
