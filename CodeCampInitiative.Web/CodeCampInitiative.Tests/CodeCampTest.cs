using AutoMapper;
using CodeCampInitiative.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace CodeCampInitiative.Tests
{
    using Data.Entities;
    using Data.Interfaces;
    using Library.Mapper;
    using Library.Services;
    using Moq;
    using System;
    using System.Threading.Tasks;
    using Xunit;

    /// <summary>
    /// Code camp test object for test code camp service functionality
    /// </summary>
    public class CodeCampTest
    {
        /// <summary>
        /// The code camp service
        /// </summary>
        private readonly CodeCampService _codeCampService;

        private IMapper _mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="CodeCampTest"/> class.
        /// </summary>
        public CodeCampTest()
        {
            var mockRepo = new Mock<ICodeCampRepository>();

            IList<CodeCamp> codeCamps = new List<CodeCamp>()
            {
                new CodeCamp
                {
                    Moniker = "99xCodeCamp",
                    Id = 1,
                    Sessions = null,
                    Name = "99x Code Camp",
                    EventDate = DateTime.Today.AddDays(1),
                    Length = 4,
                    Location = null
                },
                new CodeCamp
                {
                    Moniker = "99xCodeCamp2",
                    Id = 1,
                    Sessions = null,
                    Name = "99x Code Camp Two",
                    EventDate = DateTime.Today.AddDays(1),
                    Length = 4,
                    Location = null
                }
            };

            mockRepo.Setup(mr => mr.GetCampByMonikerAsync(
                It.IsAny<string>(), false)).ReturnsAsync((string s, bool b) => codeCamps.SingleOrDefault(x => x.Moniker == s));

            mockRepo.Setup(repo => repo.GetAllAsync(false))
                .ReturnsAsync(codeCamps);

            mockRepo.Setup(mr => mr.Insert(It.IsAny<CodeCamp>()))
                .Callback((CodeCamp codeCamp) =>
                {
                    codeCamp.Id = codeCamps.Count() + 1;
                    codeCamps.Add(codeCamp);
                }).Verifiable();

            mockRepo.SetupAllProperties();
            _mapper = MapperConfig.GetMapper();
            _codeCampService = new CodeCampService(mockRepo.Object, _mapper);

        }

        /// <summary>
        /// Gets the camp data by moniker without session returns code camp.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetCampDataByMoniker_withoutSession_returnsCodeCamp()
        {
            // Arrange
            const string expected = "99x Code Camp";
            const string moniker = "99xCodeCamp";

            // Act
            var codeCamp = await _codeCampService.GetCodeCamp(moniker);

            // Assert
            Assert.Equal(expected, codeCamp.Name);
        }

        /// <summary>
        /// Gets all code camps without session returns code camps.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task GetAllCodeCamps_withoutSession_returnsCodeCamps()
        {
            // Arrange
            const int expected = 2;

            // Act
            var codeCamps = await _codeCampService.GetCodeCamps(false);

            // Assert
            Assert.Equal(expected, codeCamps.Count());
        }

        [Fact]
        public async Task AddNewCodeCamp()
        {
            // Arrange
            var codeCampModel = new CodeCampModel()
            {
                Moniker = "99xCodeCampThree",
                Sessions = null,
                Name = "99x Code Camp Three",
                EventDate = DateTime.Today.AddDays(1),
                Length = 4,
            };

            // Act
            var codeCampDb = await _codeCampService.AddNewCodeCamp(codeCampModel);

            // Assert
            Assert.Equal(codeCampModel.Moniker, codeCampDb.Moniker);
        }
    }

}
