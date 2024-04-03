using SingleDatabaseMultiTenancy.Domain.Dto;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Base;

namespace SingleDatabaseMultiTenancy.Domain.Interfaces.Services
{
    public interface IAnimalService : IService<AnimalDto>
    {
    }
}