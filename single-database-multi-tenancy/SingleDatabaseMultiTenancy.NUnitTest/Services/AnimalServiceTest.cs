using AutoMapper;
using Moq;
using NUnit.Framework;
using SingleDatabaseMultiTenancy.Domain.Dto;
using SingleDatabaseMultiTenancy.Domain.Entities;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Data;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Services;
using SingleDatabaseMultiTenancy.NUnitTest.Common;
using SingleDatabaseMultiTenancy.Service.Services;
using System.Collections.Generic;
using System.Linq;

namespace SingleDatabaseMultiTenancy.NUnitTest.Services
{
    public class AnimalServiceTest
    {
        private Animal _animal;
        private IMapper _mapper;
        private IAnimalService _animalService;
        private Mock<IAnimalRepository> _mockAnimalRepository;

        public AnimalServiceTest()
        {
            _mapper = Utilitarios.GetMapper();
            _mockAnimalRepository = new Mock<IAnimalRepository>();
            _animalService = new AnimalService(_mapper, _mockAnimalRepository.Object);

            _animal = new Animal("Tenant01", "Cachorro");
        }

        [Test]
        public void CriarComConstrutorTest()
            => Assert.IsNotNull(new AnimalDto());

        [Test]
        public void ObterTodosTest()
        {
            IList<Animal> animalsList = new List<Animal>();
            animalsList.Add(_animal);

            _mockAnimalRepository.Setup(r => r.ObterTodos()).Returns(animalsList.AsQueryable());
            Assert.IsNotNull(_animalService.ObterTodos());
        }
    }
}