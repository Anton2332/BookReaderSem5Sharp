using System.Data;
using BLL1.Configurations;
using DAL1;
using DAL1.Interface;
using DAL1.Repositories;
using MySqlConnector;

// static class Program
// {
//     public static void Main(string[] args)
//     {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

        builder.Services.AddControllers();

        builder.Services.AddHealthChecks();

        builder.Services.AddTransient<ICommentsRepository, CommentsRepository>();
        builder.Services.AddTransient<ICommentLikesRepository, CommentLikesRepository>();

        builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();

        builder.Services.AddMapper();
        builder.Services.AddServices();

        builder.Services.AddScoped(s =>
            new MySqlConnection(
                builder.Configuration.GetConnectionString("DefaultConnection")
            )
        );
        builder.Services.AddScoped<IDbTransaction>(s =>
        {
            MySqlConnection connection = s.GetRequiredService<MySqlConnection>();
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

//     }
// }