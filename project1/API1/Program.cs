using System.Data;
using BLL1.Configurations;
using DAL1;
using DAL1.Interface;
using DAL1.Repositories;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

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