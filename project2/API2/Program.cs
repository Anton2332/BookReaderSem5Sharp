using API2.Controllers;
using BLL2.Configurations;
using BLL2.DTO.Response;
using BLL2.Interfaces;
using BLL2.Services;
using DAL2;
using DAL2.Interfaces;
using DAL2.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using BookCategoryService = BLL2.Services.BookCategoryService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

builder.Services.AddMassTransit(config =>
{
    config.UsingRabbitMq((ctx, cfg) =>
    {
        cfg.Host("rabbitmq://rabbitmq");
    });
});

builder.Services.AddOptions<MassTransitHostOptions>()
    .Configure(options =>
    {
        // if specified, waits until the bus is started before
        // returning from IHostedService.StartAsync
        // default is false
        options.WaitUntilStarted = true;

        // if specified, limits the wait time when starting the bus
        options.StartTimeout = TimeSpan.FromSeconds(10);

        // if specified, limits the wait time when stopping the bus
        options.StopTimeout = TimeSpan.FromSeconds(30);
    });

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMapper();

builder.Services.AddCors();

string? connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DBContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
);

// builder.Services.AddDbContext<DBContext>();
// options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))

builder.Services.AddTransient<IAuthorRepository, AuthorRepository>();
builder.Services.AddTransient<IBookAuthorRepository, BookAuthorRepository>();
builder.Services.AddTransient<IBookCategoryRepository, BookCategoryRepository>();
builder.Services.AddTransient<IBookRepository, BookRepository>();
builder.Services.AddTransient<IBookTagRepository, BookTagRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IChapterRepository, ChapterRepository>();
builder.Services.AddTransient<ILanguageRepository, LanguageRepository>();
builder.Services.AddTransient<IPageRepository, PageRepository>();
builder.Services.AddTransient<IRatingRepository, RatingRepository>();
builder.Services.AddTransient<IStatusRepository, StatusRepository>();
builder.Services.AddTransient<ITagRepository, TagRepository>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddTransient<IAuthorService, AuthorService>();
builder.Services.AddTransient<IBookAuthorService, BookAuthorService>();
builder.Services.AddTransient<IBookCategoryService, BookCategoryService>();
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookTagService, BookTagService>();
builder.Services.AddTransient<ICategoryService, CategoryService>();
builder.Services.AddTransient<IChapterService, ChapterService>();
builder.Services.AddTransient<ILanguageService, LanguageService>();
builder.Services.AddTransient<IPageService, PageService>();
builder.Services.AddTransient<IRatingService, RatingService>();
builder.Services.AddTransient<IStatusService, StatusService>();
builder.Services.AddTransient<ITagService, TagService>();


builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
});

builder.Services.AddTransient<IValidatorFactory, ServiceProviderValidatorFactory>();

builder.Services.AddMvc(options =>
{
    options.EnableEndpointRouting = false;
}).AddFluentValidation(configuration =>
{
    configuration.RegisterValidatorsFromAssemblies(
        AppDomain.CurrentDomain.GetAssemblies());
});


var app = builder.Build();

app.MapGrpcService<API2.Service.BookService>();

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