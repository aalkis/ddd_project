using AutoMapper;
using Be_bitirme.Application;
using Be_bitirme.Application.AddItemToBasket;
using Be_bitirme.Application.CQRS.Handlers;
using Be_bitirme.Application.CQRS.Validators;
using Be_bitirme.Application.Interfaces;
using Be_bitirme.Application.MinusItemToBasket;
using Be_bitirme.Application.RemoveItemFromBasket;
using Be_bitirme.Core.Mappers;
using Be_bitirme.Core.Repository;

using Be_bitirme.Domain.Data;
using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(typeof(RegisterUserRequestHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CheckUserRequestHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CheckProductRequestHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(UpdateBasketItemRequestHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(MergeBasketRequestHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(AddItemBasketRequestHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CheckBasketRequestHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(SubtractItemBasketRequestHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(BasketItemRemoveRequestHandler).GetTypeInfo().Assembly);
builder.Services.AddMediatR(typeof(CategoryCheckRequestHandler).GetTypeInfo().Assembly);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IBasketRepository, BasketRepository>();
builder.Services.AddAutoMapper(opt=> { opt.AddProfiles(new List<Profile>() { new CategoryProfile() }); });

builder.Services.AddControllers()
                .AddFluentValidation(c =>
                   c.RegisterValidatorsFromAssembly(
                    Assembly.GetExecutingAssembly()));

builder.Services.AddValidatorsFromAssemblyContaining<UserRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<SubtractItemValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CheckBasketRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<MergeRequestValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<AddItemBasketRequestValidator>();


builder.Services.AddDbContext<ApplicationDbContext>(opt =>
{
    opt.UseSqlServer("server=(localdb)\\mssqllocaldb; Database=BitirmeDb; Integrated Security= true ");
});
builder.Services.AddControllers().AddNewtonsoftJson(opt =>
{
    opt.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddAutoMapper(opt =>
{
    opt.AddProfiles(new List<Profile>()
    {
        new BasketItemMapProfile()
    });
});
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("GlobalCors", config =>
    {
        config.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseCors("GlobalCors");
app.MapControllers();

app.Run();
