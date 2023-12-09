using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MillionAndUp.API.Models;
using MillionAndUp.API.Models.Validators;
using MillionAndUp.Aplication.Interfaces;
using MillionAndUp.Aplication.Services;
using MillionAndUp.Infrastructure.DataAccess.Context;
using MillionAndUp.Infrastructure.DataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {

    options.SwaggerDoc("v1", new OpenApiInfo {
        Version = "v1",
        Title = "Million And Up Prueba Tecnica",
        Description = "API to obtain information about properties",
        Contact = new OpenApiContact {
            Name = "Daniel Stiven Londoño Ortega",
            Email = "daniel.londono.ortega@gmail.com"

        }
    });
    // using System.Reflection;
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddDbContext<EntityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MillionAndUpBDConnection"))
);

builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddTransient(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<OwnerModelValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<OwnerUpdateModelValidator>();


var app = builder.Build();

// Initialize

//using (var scope = app.Services.CreateScope())
//{
//    var dataContext = scope.ServiceProvider.GetRequiredService<EntityDbContext>();
//    dataContext.Database.Migrate();
//}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
