using System;

namespace SingleDatabaseMultiTenancy.Domain.Entities
{
    public class Animal : Entity
    {
        public Animal(Guid id, string tenant, string nome)
        {
            Id = id;
            Nome = nome;
            Tenant = tenant;
        }

        public Animal(string tenant, string nome)
        {
            Nome = nome;
            Tenant = tenant;
            Id = Guid.NewGuid();
        }

        public string Nome { get; set; }
    }
}