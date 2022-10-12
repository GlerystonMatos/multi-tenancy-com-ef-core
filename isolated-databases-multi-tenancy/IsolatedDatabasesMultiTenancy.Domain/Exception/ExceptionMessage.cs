using System.ComponentModel;

namespace IsolatedDatabasesMultiTenancy.Domain.Exception
{
    [DisplayName("Mensagem")]
    public class ExceptionMessage
    {
        public ExceptionMessage(string mensagem)
            => Mensagem = mensagem;

        public string Mensagem { get; set; }
    }
}