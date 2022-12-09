using API3.Modules;
using System.Reflection;
using API3.Config;
using API3.Consumer;
using API3.Interfaces;
using API3.Services;
using Application.Bookmark.Queries.GetBookmark;
using Infrastructure.Repositories;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using FluentValidation;
using Google.Protobuf.WellKnownTypes;
using GrpcClient;
using Infrastructure.Configuration;
using Infrastructure.Persistence;
using MassTransit;
using MassTransit.MultiBus;
using MediatR;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using SharedProject.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHealthChecks();

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<ChapterConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("rabbitmq://localhost");

        cfg.ReceiveEndpoint("chapter_notification", c =>
        {
            c.ConfigureConsumer<ChapterConsumer>(ctx);
        });
    });
});

// builder.Services.AddHealthChecks()
//     .AddCheck("self", () => HealthCheckResult.Healthy())
//     .AddUrlGroup(new Uri(builder.Configuration["BookUrlHC"]), name: "bookapi-check", tags: new string[] { "bookapi" });

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

builder.Services.AddOptions();
// builder.Services.Configure<UrlsConfig>(builder.Configuration.GetSection("urls"));


builder.Services.AddGrpcClient<Book.BookClient>((services, options) =>
{
    // var bookApi = services.GetRequiredService<IOptions<UrlsConfig>>().Value.GrpcBook;
    options.Address = new Uri(builder.Configuration.GetSection("urls:book").Value);
});
builder.Services.AddScoped<IBookService, BookServices>();

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