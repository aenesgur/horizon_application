using AutoMapper;
using Horizon.API.Controllers;
using Horizon.API.Mapping;
using Horizon.API.Mapping.util;
using Horizon.API.Model.Dto;
using Horizon.API.Model.PaginationFilter;
using Horizon.Core.Model;
using Horizon.Core.Service;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Horizon.API.Test
{
    public class AnimalControllerTest
    {
        private readonly Mock<IAnimalService> _mock;
        private readonly AnimalController _controller;
        private readonly IMapper _mapper;

        private IList<AnimalDto> _animalDtos;
        private IList<Animal> _animals;

        public AnimalControllerTest()
        {
            if (_mapper == null)
            {
                var mappingConfig = new MapperConfiguration(mc =>
                {
                    mc.AddProfile(new MappingProfile());
                });
                IMapper mapper = mappingConfig.CreateMapper();
                _mapper = mapper;
            }

            _animalDtos = new List<AnimalDto>()
            {
                new AnimalDto
                {
                    Id=90,
                    BirthDate= DateTime.Now,
                    Description="Lely Case Des",
                    FatherLifeNumber="Lely Case Fat",
                    MotherLifeNumber="Lely Case Mot",
                    Gender="Lely Case Gen",
                    LifeNumber="Lely Case Lif",
                    Name="Lely Case Nam"
                },
                new AnimalDto
                {
                    Id=95,
                    BirthDate= DateTime.Now,
                    Description="Two Lely Case Des",
                    FatherLifeNumber="Two Lely Case Fat",
                    MotherLifeNumber="Two Lely Case Mot",
                    Gender="Two Lely Case Gen",
                    LifeNumber="Two Lely Case Lif",
                    Name="Two Lely Case Nam"
                }
            };

            _animals = new List<Animal>()
            {
                new Animal
                {
                    Id=40,
                    BirthDate= DateTime.Now,
                    Description="Lely Case Des",
                    FatherLifeNumber="Lely Case Fat",
                    MotherLifeNumber="Lely Case Mot",
                    Gender="Lely Case Gen",
                    LifeNumber="Lely Case Lif",
                    Name="Lely Case Nam"
                },
                new Animal
                {
                    Id=45,
                    BirthDate= DateTime.Now,
                    Description="Two Lely Case Des",
                    FatherLifeNumber="Two Lely Case Fat",
                    MotherLifeNumber="Two Lely Case Mot",
                    Gender="Two Lely Case Gen",
                    LifeNumber="Two Lely Case Lif",
                    Name="Two Lely Case Nam"
                }
            };


            _mock = new Mock<IAnimalService>();
            _controller = new AnimalController(_mock.Object, _mapper);
        }

        [Theory]
        [InlineData(45)]
        public async void GetAnimalById_ActionExecute_ReturnOkWithAnimal(int id)
        {
            var animal = _animals.First(x => x.Id.Equals(id));
            _mock.Setup(x => x.GetAnimalById(id)).ReturnsAsync(animal);
            var result = await _controller.GetAnimalById(id);

            _mock.Verify(x => x.GetAnimalById(id), Times.Once);
            var resultType = Assert.IsType<OkObjectResult>(result);
            var resultModel = Assert.IsAssignableFrom<AnimalDto>(resultType.Value);
        }

        [Theory]
        [InlineData(0)]
        public async void GetAnimalById_IdInValid_ReturnBadRequest(int id)
        {
            Animal emptyAnimal = null;
            _mock.Setup(x => x.GetAnimalById(id)).ReturnsAsync(emptyAnimal);
            var result = await _controller.GetAnimalById(id);

            _mock.Verify(x => x.GetAnimalById(id), Times.Once);
            var resultType = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, resultType.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async void DeleteAnimal_IdInValid_ReturnBadRequest(int id)
        {
            Animal emptyAnimal = null;
            _mock.Setup(x => x.GetAnimalById(id)).ReturnsAsync(emptyAnimal);
            var result = await _controller.GetAnimalById(id);

            _mock.Verify(x => x.GetAnimalById(id), Times.Once);
            var resultType = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, resultType.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async void UpdateAnimal_IdInValid_ReturnBadRequest(int id)
        {
            Animal emptyAnimal = null;
            _mock.Setup(x => x.GetAnimalById(id)).ReturnsAsync(emptyAnimal);
            var result = await _controller.GetAnimalById(id);

            _mock.Verify(x => x.GetAnimalById(id), Times.Once);
            var resultType = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, resultType.StatusCode);
        }

    }
}
