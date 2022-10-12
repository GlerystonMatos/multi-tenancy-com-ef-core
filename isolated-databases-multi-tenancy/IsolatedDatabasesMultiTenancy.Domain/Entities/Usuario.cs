using System;

namespace IsolatedDatabasesMultiTenancy.Domain.Entities
{
    public class Usuario : Entity
    {
        public Usuario(Guid id, string nome, string login, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public Usuario(string nome, string login, string senha)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Id = Guid.NewGuid();
        }

        public string Nome { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }
    }
}