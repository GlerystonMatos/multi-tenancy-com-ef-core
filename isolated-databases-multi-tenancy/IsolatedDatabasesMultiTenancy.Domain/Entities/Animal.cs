using System;

namespace IsolatedDatabasesMultiTenancy.Domain.Entities
{
    public class Animal : Entity
    {
        public Animal(Guid id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public Animal(string tenant, string nome)
        {
            Nome = nome;
            Id = Guid.NewGuid();
        }

        public string Nome { get; set; }
    }
}