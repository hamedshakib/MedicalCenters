using Microsoft.OpenApi;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace MedicalCenters.API;

public class EnumSchemaFilter : ISchemaFilter
{
    public void Apply(IOpenApiSchema schema, SchemaFilterContext context)
    {
        if (!context.Type.IsEnum)
            return;

        var enumValues = Enum.GetValues(context.Type).Cast<Enum>();

        if (schema is OpenApiSchema concrete)
        {
            concrete.Extensions ??= new Dictionary<string, IOpenApiExtension>();

            concrete.Enum = enumValues
                .Select(e => new JsonNodeExtension(Convert.ToInt32(e)).Node)
                .ToList();

            concrete.Type = JsonSchemaType.Integer;
            concrete.Format = "int32";

            var enumDescriptions = enumValues
                .Select(e => $"{Convert.ToInt32(e)}: {Enum.GetName(context.Type, e)}");

            var availableValuesText = "<b>Available values:</b><br/>" + string.Join("<br/>", enumDescriptions);

            concrete.Description = string.IsNullOrWhiteSpace(schema.Description)
                ? availableValuesText
                : $"{schema.Description}<br/><br/>{availableValuesText}";

        }
    }
}