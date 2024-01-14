
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder();
builder.Services.SwaggerDocument(o => o.DocumentSettings = d => d.MarkNonNullablePropsAsRequired());
builder.Services.AddFastEndpoints().AddAuthorization();

var app = builder.Build();


app.UseFastEndpoints().UseSwaggerGen();
app.Run();