using System;

namespace SingleDatabaseMultiTenancy.Domain.Entities
{
    public class Entity
    {
        public Guid Id { get; set; }

        public string Tenant { get; set; }
    }
}