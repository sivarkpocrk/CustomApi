using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomApi.Data;
using CustomApi.Models;
using CustomApi.Services.Interfaces;
using System.Collections.Generic;
using System.Collections.Generic;
using Microsoft.OpenApi.Models;

public class ExcludeSchemasFilter : ISchemaFilter
{
    // List of schema names to exclude
    private readonly HashSet<string> _excludedSchemas = new HashSet<string>
    {
        nameof(AuthorDTO),
        nameof(ProductDTO)
    };

    public void Apply(OpenApiSchema schema, SchemaFilterContext context)
    {
        // Remove schema properties if the class is in the excluded list
        if (_excludedSchemas.Contains(context.Type.Name))
        {
            schema.Properties.Clear();
        }
    }
}
