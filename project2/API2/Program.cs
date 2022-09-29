using BLL2.Configurations;
using BLL2.Interfaces;
using BLL2.Services;
using DAL2;
using DAL2.Interfaces;
using DAL2.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMapper();

builder.Services.AddCors();

builder.Services.AddDbContext<DBContext>();
// options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

builder.Services.AddTransient<ITestRepository, TestRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<ITestService, TestService>();

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});

builder.Services.AddMvc();
    
    
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