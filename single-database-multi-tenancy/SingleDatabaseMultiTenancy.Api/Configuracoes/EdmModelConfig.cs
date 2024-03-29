﻿using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using SingleDatabaseMultiTenancy.Domain.Dto;

namespace SingleDatabaseMultiTenancy.Api.Configuracoes
{
    public class EdmModelConfig
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder odataBuilder = new ODataConventionModelBuilder();

            odataBuilder.EntitySet<AnimalDto>("Animal");
            odataBuilder.EntitySet<UsuarioDto>("Usuario");

            return odataBuilder.GetEdmModel();
        }
    }
}