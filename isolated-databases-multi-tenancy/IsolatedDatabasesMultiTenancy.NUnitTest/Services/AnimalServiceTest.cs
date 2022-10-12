using AutoMapper;
using Moq;
using NUnit.Framework;
using IsolatedDatabasesMultiTenancy.Domain.Dto;
using IsolatedDatabasesMultiTenancy.Domain.Entities;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Data;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Services;
using IsolatedDatabasesMultiTenancy.NUnitTest.Common;
using IsolatedDatabasesMultiTenancy.Service.Services;
using System.Collections.Generic;
using System.Linq;

namespace IsolatedDatabasesMultiTenancy.NUnitTest.Services
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