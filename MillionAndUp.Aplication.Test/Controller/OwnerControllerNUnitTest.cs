using System.Security.Claims;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MillionAndUp.API.Controllers;
using MillionAndUp.API.Mapper;
using MillionAndUp.API.Models;
using MillionAndUp.Aplication.Dtos;
using MillionAndUp.Aplication.Interfaces;
using Moq;
using NUnit.Framework;

namespace MillionAndUp.Aplication.Test.Controller
{
    [TestFixture]
    public class OwnerControllerNUnitTest
    {
        private MockRepository _mockRepository;
        private Mock<IOwnerService> _mockService;
        private IMapper _mapper;

        private static readonly OwnerDto _ownerDto = new() {
            IdOwner = Guid.Parse("39F86D2E-9F7B-47B3-BA6E-B9CB401228D2"),
            Name = "Prueba",
            Address = "Calle 17",
            Birthday = DateTime.Parse("1993/03/28"),
        };
        private static readonly List<OwnerDto> _listOwnerDto = new()
{
            _ownerDto,
            new OwnerDto() { IdOwner = Guid.NewGuid(), Name = "Prueba 2", Birthday = DateTime.Parse("1993/03/28") }
        };

        private static readonly OwnerModel _ownerModel = new() {            
            Name = "Prueba",
            Address = "Calle 17",
            Birthday = DateTime.Parse("1993/03/28"),
        };

        private static readonly OwnerUpdateModel _ownerUpdateModel = new() {
            IdOwner = Guid.Parse("39F86D2E-9F7B-47B3-BA6E-B9CB401228D2"),
            Name = "Prueba",
            Address = "Calle 17",
            Birthday = DateTime.Parse("1993/03/28"),
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
            _mockService = _mockRepository.Create<IOwnerService>();
        }

        private OwnerController CreateOwnerController()
        {
            var identity = new ClaimsIdentity();
            var contextUser = new ClaimsPrincipal(identity);
            var httpContext = new DefaultHttpContext() {
                User = contextUser
            };
            var controllerContext = new ControllerContext() {
                HttpContext = httpContext,
            };

            return new OwnerController(
                _mockService.Object,
                _mapper) {                
                ControllerContext = controllerContext
            };
        }

        [Test]        
        public async Task OwnerController_GetById_ReturnsOk()
        {
            // Arrange
            Guid id = Guid.Parse("39F86D2E-9F7B-47B3-BA6E-B9CB401228D2");
            _mockService.Setup(sp => sp.Get(id)).ReturnsAsync(_ownerDto);
            var ownerController = CreateOwnerController();

            // Act
            var result = await ownerController.Get(id);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var model = okResult.Value as OwnerDto;
            Assert.IsNotNull(model);
            _mockService.VerifyAll();
        }

        [Test]        
        public async Task OwnerController_GetAll_ReturnOk()
        {
            // Arrange
            _mockService.Setup(x => x.GetAll())
                                .ReturnsAsync(_listOwnerDto);
            var ownerController = CreateOwnerController();

            // Act
            var result = await ownerController.GetAll();

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var model = okResult.Value as IEnumerable<OwnerDto>;
            Assert.IsNotNull(model);
            CollectionAssert.AreEqual(_listOwnerDto, model.ToList());
            _mockService.VerifyAll();
        }

        [Test]
        public void Ownercontroller_Post_ReturnOk()
        {
            // Arrange
            _mockService.Setup(x => x.Post(It.IsAny<OwnerDto>())).Returns(true);            

            var ownerController = CreateOwnerController();
            OwnerModel request = _ownerModel;

            // Act
            var result = ownerController.Post(request);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var response = okResult.Value;
            Assert.AreNotEqual(0, response);
            _mockService.VerifyAll();
        }

        [Test]       
        public async Task OwnerController_Put_ReturnsOk()
        {
            // Arrange
            _mockService.Setup(x => x.Put(It.IsAny<OwnerDto>())).Returns(true);

            var ownerController = CreateOwnerController();
            OwnerUpdateModel request = _ownerUpdateModel;

            // Act
            var result = ownerController.Put(request);

            // Assert
            var okResult = result as ObjectResult;
            Assert.IsNotNull(okResult);
            Assert.IsTrue(okResult is OkObjectResult);
            Assert.AreEqual(StatusCodes.Status200OK, okResult.StatusCode);

            var response = okResult.Value;
            Assert.AreNotEqual(0, response);
            _mockService.VerifyAll();

            _mockService.VerifyAll();
        }

    }
}
