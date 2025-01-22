using Microservice.Catalog.Api.Options;
using Microservice.Catalog.Api.Repositories;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Microservice.Catalog.Api.Features.Categories;
using System.Reflection;
using Microservice.Shared.Extensions;
using Microservice.Catalog.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOptionsExt();
builder.Services.AddDatabaseServiceExt();

builder.Services.AddCommonServiceExt(typeof(CatalogAssembly));


var app = builder.Build();

app.AddCategoryGroupEndpointExt();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.Run();

