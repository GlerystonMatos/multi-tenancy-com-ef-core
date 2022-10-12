using System;

namespace SingleDatabaseMultiTenancy.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario(Guid id, string tenant, string nome, string login, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
            Tenant = tenant;
        }

        public Usuario(string tenant, string nome, string login, string senha)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Tenant = tenant;
            Id = Guid.NewGuid();
        }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }
    }
}