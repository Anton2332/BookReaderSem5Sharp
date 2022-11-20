using System.Data;
using API1.Consumer;
using BLL1.Configurations;
using DAL1;
using DAL1.Interface;
using DAL1.Repositories;
using MassTransit;
using MassTransit.MultiBus;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHealthChecks();
// builder.Services.AddMassTransit(x =>
// {
//     // x.AddConsumer<BookConsumer>(typeof(BookConsumerDefinition));
//     // x.SetKebabCaseEndpointNameFormatter();
//     // x.UsingRabbitMq((context, cfg) => cfg.ConfigureEndpoints(context));
//     x.AddConsumer<BookConsumer>();
//     x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(cfg =>
//     {
//         // cfg.UseHealthCheck(provider);
//         cfg.Host(new Uri("rabbitmq://localhost"), h =>
//         {
//             h.Username("guest");
//             h.Password("guest");
//         });
//         cfg.ReceiveEndpoint("book_comment_create", ep =>
//         {
//             ep.PrefetchCount = 16;
//             ep.UseMessageRetry(r => r.Interval(2, 100));
//             ep.ConfigureConsumer<BookConsumer>(provider);
//         });
//     }));
// });

builder.Services.AddMassTransit(config =>
{
    config.AddConsumer<BookConsumer>();

    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("rabbitmq://localhost");
        
        cfg.ReceiveEndpoint("book_comment_create", c =>
        {
            c.ConfigureConsumer<BookConsumer>(ctx);
        });
    });
});


builder.Services.AddTransient<ICommentsRepository, CommentsRepository>();
builder.Services.AddTransient<IBookCommentsRepository, BookCommentsRepository>();
builder.Services.AddTransient<ICommentLikesRepository, CommentLikesRepository>();
builder.Services.AddTransient<ILikeRepository, LikeRepository>();
builder.Services.AddTransient<IUserCommentsRepository, UserCommentsRepository>();

builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

builder.Services.AddMapper();
builder.Services.AddServices();

builder.Services.AddScoped(s =>
    new SqlConnection(
        builder.Configuration.GetConnectionString("DefaultConnection")
        )
);
builder.Services.AddScoped<IDbTransaction>(s =>
{
    SqlConnection connection = s.GetRequiredService<SqlConnection>();
    connection.Open();
    return connection.BeginTransaction();
});

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