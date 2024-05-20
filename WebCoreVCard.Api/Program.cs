using Microsoft.EntityFrameworkCore;
using WebCoreVCard.Infrastructure.Mappers;
using WebCoreVCard.Infrastructure.Models;
using AutoMapper;
using WebCoreVCard.Infrastructure.Repositories;
using WebCoreVCard.Infrastructure.Repositories.Interfaces;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

//Configure sql server connection.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Adding repositories
builder.Services.AddScoped<IUsersRepository, UsersRepository>();

//Adding AutoMapper
builder.Services.AddAutoMapper(typeof(WebCoreVCardMapper));

// Add services to the container.

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4800", "http://localhost:8045")
                              .AllowAnyHeader()
                              .AllowAnyMethod();
                      });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IFileProvider>(
    new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
