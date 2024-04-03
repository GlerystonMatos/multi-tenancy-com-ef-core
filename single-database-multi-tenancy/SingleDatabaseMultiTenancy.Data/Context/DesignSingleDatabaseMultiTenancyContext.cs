using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SingleDatabaseMultiTenancy.Service.Services;

namespace SingleDatabaseMultiTenancy.Data.Context
{
    public class DesignSingleDatabaseMultiTenancyContext : IDesignTimeDbContextFactory<SingleDatabaseMultiTenancyContext>
    {
        public SingleDatabaseMultiTenancyContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<SingleDatabaseMultiTenancyContext> builder = new DbContextOptionsBuilder<SingleDatabaseMultiTenancyContext>();
            builder.UseSqlServer("Data Source=10.0.0.131\\SQLEXPRESS;Initial Catalog=SingleDatabaseMultiTenancy;Persist Security Info=True;User ID=sa;Password=1234");
            return new SingleDatabaseMultiTenancyContext(builder.Options, new TenantService());
        }
    }
}