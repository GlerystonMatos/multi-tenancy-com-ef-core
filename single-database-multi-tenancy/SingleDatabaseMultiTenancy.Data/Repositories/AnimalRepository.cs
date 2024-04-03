using SingleDatabaseMultiTenancy.Data.Base;
using SingleDatabaseMultiTenancy.Data.Context;
using SingleDatabaseMultiTenancy.Domain.Entities;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Data;

namespace SingleDatabaseMultiTenancy.Data.Repositories
{
    public class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(SingleDatabaseMultiTenancyContext context) : base(context)
        {
        }
    }
}