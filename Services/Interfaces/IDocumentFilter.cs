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

public class RemoveSchemasDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        // Remove all components, including schemas
        swaggerDoc.Components.Schemas.Clear();
    }
}
