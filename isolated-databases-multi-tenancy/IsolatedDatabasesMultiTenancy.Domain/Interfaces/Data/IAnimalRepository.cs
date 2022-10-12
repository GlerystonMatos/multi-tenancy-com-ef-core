using IsolatedDatabasesMultiTenancy.Domain.Entities;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Common;

namespace IsolatedDatabasesMultiTenancy.Domain.Interfaces.Data
{
    public interface IAnimalRepository : IRepository<Animal>
    {
    }
}