using System.ComponentModel;

namespace SingleDatabaseMultiTenancy.Domain.Exception
{
    [DisplayName("Mensagem")]
    public class ExceptionMessage
    {
        public ExceptionMessage(string mensagem)
            => Mensagem = mensagem;

        public string Mensagem { get; set; }
    }
}