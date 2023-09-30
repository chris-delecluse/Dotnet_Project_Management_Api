using Carter;
using ProjectManagement;
using ProjectManagement.CQRS.Adapter;
using ProjectManagement.Database.Adapter;
using ProjectManagement.Web.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDatabaseAdapterServices();
builder.Services.RegisterCqrsAdapterServices();
builder.Services.RegisterDomainServices();
builder.Services.RegisterWebApiServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapCarter();

app.Run();
