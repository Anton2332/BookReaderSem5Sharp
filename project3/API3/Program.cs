using API3.Modules;
using System.Reflection;
using Application.Bookmark.Queries.GetBookmark;
using Infrastructure.Repositories;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using GrpcClient;
using Infrastructure.Configuration;
using Infrastructure.Persistence;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddCors(option =>
{
    option.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyMethod().AllowAnyHeader().WithOrigins("http://localhost:3000");
    });
});

builder.Services.AddApiVersioning(options => { options.AssumeDefaultVersionWhenUnspecified = true;});



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(typeof(GetBookmarkQuery).GetTypeInfo().Assembly);

builder.Services.Configure<DataConfiguration>(
    options =>
    {
        options.ConnectionString = builder.Configuration.GetSection("MongoDB:ConnectionString").Value;
        options.Database = builder.Configuration.GetSection("MongoDB:Database").Value;
    });
builder.Services.AddSingleton<IDataContext, DataContext>();

builder.Services.AddAutoMapper(x =>
{
    x.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});

builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(b =>
    {
        b.RegisterModule(new Modules());
        b.RegisterModule(new MediatorModule());
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();