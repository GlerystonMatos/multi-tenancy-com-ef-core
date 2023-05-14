using IsolatedDatabasesMultiTenancy.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace IsolatedDatabasesMultiTenancy.Data.Context
{
    public class DesignIsolatedDatabasesMultiTenancyContext : IDesignTimeDbContextFactory<IsolatedDatabasesMultiTenancyContext>
    {
        public IsolatedDatabasesMultiTenancyContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<IsolatedDatabasesMultiTenancyContext> builder = new DbContextOptionsBuilder<IsolatedDatabasesMultiTenancyContext>();
            builder.UseSqlServer("Data Source=10.0.0.131\\SQLEXPRESS;Initial Catalog=IsolatedDatabasesMultiTenancy00;Persist Security Info=True;User ID=sa;Password=1234");
            return new IsolatedDatabasesMultiTenancyContext(builder.Options, new TenantService(), null);
        }
    }
}