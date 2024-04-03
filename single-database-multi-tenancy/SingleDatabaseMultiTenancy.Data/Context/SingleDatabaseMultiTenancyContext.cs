using Microsoft.EntityFrameworkCore;
using SingleDatabaseMultiTenancy.Data.Configuration;
using SingleDatabaseMultiTenancy.Domain.Entities;
using SingleDatabaseMultiTenancy.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace SingleDatabaseMultiTenancy.Data.Context
{
    public class SingleDatabaseMultiTenancyContext : DbContext
    {
        private readonly ITenantService _tenantService;

        public SingleDatabaseMultiTenancyContext(DbContextOptions<SingleDatabaseMultiTenancyContext> options, ITenantService tenantService) : base(options)
            => _tenantService = tenantService;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new AnimalConfig());
            modelBuilder.ApplyConfiguration(new UsuarioConfig());

            modelBuilder.Entity<Animal>().HasQueryFilter(a => a.Tenant == _tenantService.Get());
            modelBuilder.Entity<Usuario>().HasQueryFilter(u => u.Tenant == _tenantService.Get());

            IList<Usuario> usuarios = new List<Usuario>();
            usuarios.Add(new Usuario(Guid.Parse("d78a657f-66fa-43f2-a535-212e6bfb6630"), "Tenant01", "Teste 01", "Teste01", "1234"));
            usuarios.Add(new Usuario(Guid.Parse("10b42acc-45bd-460a-9edd-d568ff236e37"), "Tenant02", "Teste 02", "Teste02", "4567"));

            modelBuilder.Entity<Usuario>().HasData(usuarios);

            IList<Animal> animais = new List<Animal>();
            animais.Add(new Animal(Guid.Parse("1dfc4a8d-7ed1-443c-9cc7-ac71ea9d003b"), "Tenant01", "Cachorro"));
            animais.Add(new Animal(Guid.Parse("8b5c8482-f2ec-4cf6-aaa8-20ec25112cd7"), "Tenant02", "Hamster"));

            modelBuilder.Entity<Animal>().HasData(animais);
        }
    }
}