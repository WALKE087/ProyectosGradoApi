using Domain.Repositories;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Repositories;
using Service.Abstractions;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<RepositoryDbContext>();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
if (builder.Environment.IsDevelopment())
{
    // Configuración desde User Secrets
    var postgresSettings = builder.Configuration
    .GetSection("secreto")
    .Get<PostgresSettings>();

    var connectionString = $"Host={postgresSettings?.Host};Port={postgresSettings?.Port};" +
                           $"Database={postgresSettings?.Database};Username={postgresSettings?.Username};" +
                           $"Password={postgresSettings?.Password}";

    // Configurar DbContext
    builder.Services.AddDbContext<RepositoryDbContext>(options =>
        options.UseNpgsql(connectionString));

    // ❗ Mover esta línea antes de Build
    builder.Services.Configure<PostgresSettings>(
        builder.Configuration.GetSection("secreto"));
}
else { 
var postgresSettings = new PostgresSettings
{
    Host = Environment.GetEnvironmentVariable("POSTGRES_HOST") ?? "",
    Port = Environment.GetEnvironmentVariable("POSTGRES_PORT") ?? "11550",
    Database = Environment.GetEnvironmentVariable("POSTGRES_DB") ?? "",
    Username = Environment.GetEnvironmentVariable("POSTGRES_USER") ?? "",
    Password = Environment.GetEnvironmentVariable("POSTGRES_PASSWORD") ?? ""
};

var connectionString = $"Host={postgresSettings.Host};Port={postgresSettings.Port};" +
                       $"Database={postgresSettings.Database};Username={postgresSettings.Username};" +
                       $"Password={postgresSettings.Password}";

builder.Services.AddDbContext<RepositoryDbContext>(options =>
    options.UseNpgsql(connectionString));
}
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/index.html", () => Results.Redirect("/swagger"));
    app.UseCors("AllowAnyOrigin");
}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapGet("/index.html", () => Results.Redirect("/swagger"));
}

if (app.Environment!.IsDevelopment())
{
}
else
{
    app.Urls.Add("http://+:8080");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
