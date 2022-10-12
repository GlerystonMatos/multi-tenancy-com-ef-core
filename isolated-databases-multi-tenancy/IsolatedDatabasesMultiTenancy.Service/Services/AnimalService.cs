using AutoMapper;
using AutoMapper.QueryableExtensions;
using IsolatedDatabasesMultiTenancy.Domain.Dto;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Data;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Services;
using System.Linq;

namespace IsolatedDatabasesMultiTenancy.Service.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;

        public AnimalService(IMapper mapper, IAnimalRepository animalRepository)
        {
            _mapper = mapper;
            _animalRepository = animalRepository;
        }

        public IQueryable<AnimalDto> ObterTodos()
            => _animalRepository.ObterTodos().ProjectTo<AnimalDto>(_mapper.ConfigurationProvider);
    }
}