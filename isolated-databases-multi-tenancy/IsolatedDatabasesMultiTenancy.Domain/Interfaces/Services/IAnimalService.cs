using IsolatedDatabasesMultiTenancy.Domain.Dto;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Base;

namespace IsolatedDatabasesMultiTenancy.Domain.Interfaces.Services
{
    public interface IAnimalService : IService<AnimalDto>
    {
    }
}