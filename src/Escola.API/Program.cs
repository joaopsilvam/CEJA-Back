using Enceja.Infrastructure;
using Enceja.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Enceja.Domain.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Enceja.Domain.Interfaces;
using Enceja.Domain.Entities;
using Enceja.Application.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IO;
using System.Text;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

string dbPath;
if (builder.Environment.IsProduction())
{
    var dataPath = Path.Combine(Environment.GetEnvironmentVariable("HOME") ?? ".", "site", "data");
    dbPath = Path.Combine(dataPath, "databaseProd.db");

    if (!Directory.Exists(dataPath))
    {
        Directory.CreateDirectory(dataPath);
    }

    if (!File.Exists(dbPath))
    {
        File.Create(dbPath).Dispose();
    }
}
else
{
    dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Database", "databaseDev.db");

    var devDir = Path.GetDirectoryName(dbPath);
    if (!Directory.Exists(devDir))
    {
        Directory.CreateDirectory(devDir);
    }

    if (!File.Exists(dbPath))
    {
        File.Create(dbPath).Dispose();
    }
}

var connectionString = $"Data Source={dbPath}";

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));

var jwtSecret = "12345678";
var key = Encoding.UTF8.GetBytes(jwtSecret);

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Enceja.API",
            ValidAudience = "Enceja.API",
            IssuerSigningKey = new SymmetricSecurityKey(key)
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IClassRepository, ClassRepository>();
builder.Services.AddScoped<IGradeRepository, GradeRepository>();

builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IClassService, ClassService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped<IGradeService, GradeService>();
builder.Services.AddScoped<ITeacherService, TeacherService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IPasswordHasher<Student>, PasswordHasher<Student>>();
builder.Services.AddScoped<IPasswordHasher<Teacher>, PasswordHasher<Teacher>>();
builder.Services.AddSingleton<TokenService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Enceja.API", Version = "v1" });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder
            .WithOrigins("http://localhost:4200",
            "https://ceja.netlify.app")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (!context.Users.Any(u => u.RoleId == 1))
    {
        var password = "admin123"; 
        var passwordHasher = new PasswordHasher<User>();
        var admin = new User
        {
            Name = "Usuario Administrador",
            Email = "admin@escola.com",
            Password = "", 
            Document = "00000000000",
            Phone = "11999999999",
            Address = "Sistema - Inicialização",
            BornDate = new DateTime(1980, 1, 1),
            RoleId = 1
        };

        admin.Password = passwordHasher.HashPassword(admin, password);

        context.Users.Add(admin);
        context.SaveChanges();
    }
}


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Enceja.API v1");
    c.RoutePrefix = "swagger";
});

app.Use(async (context, next) =>
{
    if (context.Request.Path == "/")
    {
        context.Response.Redirect("/swagger");
        return;
    }

    await next();
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors("AllowSpecificOrigin");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
