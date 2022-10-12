using SingleDatabaseMultiTenancy.Domain.Entities;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Common;

namespace SingleDatabaseMultiTenancy.Domain.Interfaces.Data
{
    public interface IAnimalRepository : IRepository<Animal>
    {
    }
}