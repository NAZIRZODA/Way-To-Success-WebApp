using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;
using WTSuccess.Application.Common.Interfaces;
using WTSuccess.Application.Common.Interfaces.Repositories;
using WTSuccess.Application.Context;
using WTSuccess.Application.Mappers;
using WTSuccess.Application.Services;
using WTSuccess.Application.Validations;
using WTSuccess.Infrastructure.Persistence.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
//Register FluentValidation
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssembly(typeof(CreateStudentValidator).Assembly);
//Register AutoMapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfiguration).Assembly);

builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStudentRepository, StudentRepository>();
// builder.Services.AddScoped<ILanguageRepository, CourseRepository>();
// builder.Services.AddScoped<IExamRepository, ExamRepository>();
builder.Services.AddDbContext<WTSuccessContext>(optionsAction=>optionsAction.UseNpgsql("Host=localhost;Port=5432;Username=postgres;DataBase=WayToSuccess;Password=2415"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

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
