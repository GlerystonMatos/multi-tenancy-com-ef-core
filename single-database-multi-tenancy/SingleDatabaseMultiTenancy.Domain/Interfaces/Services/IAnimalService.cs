using SingleDatabaseMultiTenancy.Domain.Dto;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Common;

namespace SingleDatabaseMultiTenancy.Domain.Interfaces.Services
{
    public interface IAnimalService : IService<AnimalDto>
    {
    }
}