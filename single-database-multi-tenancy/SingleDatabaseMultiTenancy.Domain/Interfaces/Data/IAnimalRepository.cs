using SingleDatabaseMultiTenancy.Domain.Entities;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Base;

namespace SingleDatabaseMultiTenancy.Domain.Interfaces.Data
{
    public interface IAnimalRepository : IRepository<Animal>
    {
    }
}