using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel.WebApi.OpenApi
{
    public class SwaggerDefaultValues : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            var apiDescriptoin = context.ApiDescription;
            operation.Deprecated = apiDescriptoin.IsDeprecated();

            if (operation.Parameters == null)
                return;

            foreach (var parameter in operation.Parameters)
            {
                var description = apiDescriptoin.ParameterDescriptions.First(pd => pd.Name == parameter.Name);
                parameter.Description ??= description.ModelMetadata.Description;

                if (parameter.Schema.Default == null && description.DefaultValue != null)
                    parameter.Schema.Default = new OpenApiString(description.DefaultValue.ToString());

                parameter.Required |= description.IsRequired;
            }



        }
    }
}
