using AutoMapper;
using Horizon.API.Controllers;
using Horizon.API.Mapping;
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
    public class FeedingVisitControllerTest
    {
        private readonly Mock<IFeedVisitService> _feedVisitMock;
        private readonly Mock<IAnimalService> _animalMock;
        private readonly FeedingVisitController _controller;
        private readonly IMapper _mapper;

        private IList<FeedVisit> _feedVisit;

        public FeedingVisitControllerTest()
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

            _feedVisit = new List<FeedVisit>()
            {
                new FeedVisit
                {
                    Id=20,
                    FeedingDate=DateTime.Now,
                    Intake=5,
                    AnimalId=5,
                    Animal = new Animal()
                },
                new FeedVisit
                {
                    Id=25,
                    FeedingDate=DateTime.Now,
                    Intake=8,
                    AnimalId=6,
                    Animal = new Animal()
                }
            };

            _animalMock = new Mock<IAnimalService>();
            _feedVisitMock = new Mock<IFeedVisitService>();
            _controller = new FeedingVisitController(_feedVisitMock.Object,_animalMock.Object, _mapper);
        }

        [Theory]
        [InlineData(25)]
        public async void GetFeedVisitsById_ActionExecute_ReturnOkWithFeedVisit(int id)
        {
            var feedVisit = _feedVisit.First(x => x.Id.Equals(id));
            _feedVisitMock.Setup(x => x.GetFeedVisitById(id)).ReturnsAsync(feedVisit);
            var result = await _controller.GetFeedVisitsById(id);

            _feedVisitMock.Verify(x => x.GetFeedVisitById(id), Times.Once);
            var resultType = Assert.IsType<OkObjectResult>(result);
            var resultModel = Assert.IsAssignableFrom<FeedVisit>(resultType.Value);
        }

        [Theory]
        [InlineData(0)]
        public async void GetFeedVisitsById_IdInValid_ReturnBadRequest(int id)
        {
            FeedVisit emptyFeedVisit = null;
            _feedVisitMock.Setup(x => x.GetFeedVisitById(id)).ReturnsAsync(emptyFeedVisit);
            var result = await _controller.GetFeedVisitsById(id);

            _feedVisitMock.Verify(x => x.GetFeedVisitById(id), Times.Once);
            var resultType = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, resultType.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async void DeleteFeedVisit_IdInValid_ReturnBadRequest(int id)
        {
            FeedVisit emptyFeedVisit = null;
            _feedVisitMock.Setup(x => x.GetFeedVisitById(id)).ReturnsAsync(emptyFeedVisit);
            var result = await _controller.GetFeedVisitsById(id);

            _feedVisitMock.Verify(x => x.GetFeedVisitById(id), Times.Once);
            var resultType = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, resultType.StatusCode);
        }

        [Theory]
        [InlineData(0)]
        public async void UpdateFeedVisit_IdInValid_ReturnBadRequest(int id)
        {
            FeedVisit emptyFeedVisit = null;
            _feedVisitMock.Setup(x => x.GetFeedVisitById(id)).ReturnsAsync(emptyFeedVisit);
            var result = await _controller.GetFeedVisitsById(id);

            _feedVisitMock.Verify(x => x.GetFeedVisitById(id), Times.Once);
            var resultType = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal(400, resultType.StatusCode);
        }
    }
}
