using IsolatedDatabasesMultiTenancy.Data.Common;
using IsolatedDatabasesMultiTenancy.Data.Context;
using IsolatedDatabasesMultiTenancy.Domain.Entities;
using IsolatedDatabasesMultiTenancy.Domain.Interfaces.Data;

namespace IsolatedDatabasesMultiTenancy.Data.Repositories
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(IsolatedDatabasesMultiTenancyContext context) : base(context)
        {
        }
    }
}