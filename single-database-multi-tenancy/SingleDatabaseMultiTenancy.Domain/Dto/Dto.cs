using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SingleDatabaseMultiTenancy.Domain.Dto
{
    [DisplayName("Dto")]
    public class Dto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo 'Tenant' obrigatório")]
        public string Tenant { get; set; }
    }
}