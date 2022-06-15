using BookStore.Business;
using BookStore.DataAccess.Data;
using BookStore.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("db");

builder.Services.AddDbContext<BookStoreDbContext>(conf => conf.UseSqlServer(connectionString));
builder.Services.AddScoped<IBookRepository, EFBookRepository>();
builder.Services.AddScoped<IBookService, BookService>();


var app = builder.Build();

var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<BookStoreDbContext>();
CreateDatabase.Create(dbContext);

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
