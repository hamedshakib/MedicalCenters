using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;
using System.Reflection;

namespace MedicalCenters.API
{
    public class DescriptionSchemaFilter : ISchemaFilter
    {
        public void Apply(OpenApiSchema schema, SchemaFilterContext context)
        {
            if (context.Type.IsClass && schema.Properties != null)
            {
                foreach (var property in context.Type.GetProperties())
                {
                    var descriptionAttribute = property.GetCustomAttribute<DescriptionAttribute>();
                    if (descriptionAttribute != null)
                    {
                        var propertyName = char.ToLowerInvariant(property.Name[0]) + property.Name.Substring(1);
                        if (schema.Properties.ContainsKey(propertyName))
                        {
                            schema.Properties[propertyName].Description = descriptionAttribute.Description;
                        }
                    }
                }
            }
        }
    }
}
