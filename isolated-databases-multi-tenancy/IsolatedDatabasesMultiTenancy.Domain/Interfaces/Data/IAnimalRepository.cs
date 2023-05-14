using IsolatedDatabasesMultiTenancy.Domain.Entities;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Base;

namespace IsolatedDatabasesMultiTenancy.Domain.Interfaces.Data
{
    public interface IAnimalRepository : IRepository<Animal>
    {
    }
}