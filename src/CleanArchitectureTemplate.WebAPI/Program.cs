using CleanArchitectureTemplate.Application.Behaviors;
using CleanArchitectureTemplate.Application.IServices;
using CleanArchitectureTemplate.Application.Services;
using CleanArchitectureTemplate.Domain.Entities;
using CleanArchitectureTemplate.Domain.IRepositories;
using CleanArchitectureTemplate.Infrastructure.Services;
using CleanArchitectureTemplate.Persistance.Contexts;
using CleanArchitectureTemplate.Persistance.Repositories;
using CleanArchitectureTemplate.Persistance.Services;
using CleanArchitectureTemplate.WebAPI.Middleware;
using CleanArchitectureTemplate.WebAPI.Options;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddApplicationPart(typeof(CleanArchitectureTemplate.Presentation.AssemblyReference).Assembly);
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen(setup =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = JwtBearerDefaults.AuthenticationScheme,
        Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme

        }
    };

    setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    setup.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});

builder.Services.AddAutoMapper(typeof(CleanArchitectureTemplate.Persistance.AssemblyReference).Assembly);


builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlConnection"), b => b.MigrationsAssembly("CleanArchitectureTemplate.Persistance"));
});
builder.Services.AddIdentity<User, Role>(options =>
{
    //options.Password.RequiredLength = 6;
    //options.Password.RequireDigit = true;
    //options.Password.RequireLowercase = true;
    //options.Password.RequireUppercase = true;
    //options.Password.RequireNonAlphanumeric = false;
    //options.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.ConfigureOptions<JwtOptionsConfiguration>();
builder.Services.ConfigureOptions<JwtBearerOptionsConfiguration>();

builder.Services.AddAuthentication().AddJwtBearer();
builder.Services.AddAuthorization();

builder.Services.AddMediatR(cfr => cfr.RegisterServicesFromAssembly(typeof(CleanArchitectureTemplate.Application.AssemblyReference).Assembly));
builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
builder.Services.AddValidatorsFromAssembly(typeof(CleanArchitectureTemplate.Application.AssemblyReference).Assembly);
builder.Services.AddScoped(typeof(IGenericCommandRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<IUserRoleService, UserRoleService>();
builder.Services.AddScoped<IJwtGenerator, JwtGenerator>();
builder.Services.AddTransient<ExceptionMiddleware>();

var app = builder.Build();

app.MapScalarApiReference(options =>
{
    options.WithTitle("Deneme").WithTheme(ScalarTheme.DeepSpace).WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddlewareExtensions();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
