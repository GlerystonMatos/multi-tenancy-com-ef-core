﻿using IsolatedDatabasesMultiTenancy.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IsolatedDatabasesMultiTenancy.Data.Configuration
{
    public class AnimalConfig : IEntityTypeConfiguration<Animal>
    {
        public void Configure(EntityTypeBuilder<Animal> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).IsRequired();
            builder.Property(a => a.Nome).IsRequired();
        }
    }
}