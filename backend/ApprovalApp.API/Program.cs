using ApprovalApp.Application;
using ApprovalApp.Data;
using ApprovalApp.Data.PersonsRepository;
using ApprovalApp.Domain.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// Добавление Swagger и XML комментариев к коду в swagger
builder.Services.AddSwaggerGen(options =>
{
    options.IncludeXmlComments(Path.Combine(
        AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"), true);
});
builder.Services.AddDbContext<ApprovalDbContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("ApprovalDbConnection"),
        b => b.MigrationsAssembly("ApprovalApp.API")));

builder.Services.AddScoped<IPersonsService, PersonsService>();
builder.Services.AddScoped<IPersonsPerository, PersonsRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.UseCors(x =>
{
    x.WithHeaders().AllowAnyHeader();
    x.WithOrigins("http://localhost:3000");
    x.WithMethods().AllowAnyMethod();
});

app.Run();
