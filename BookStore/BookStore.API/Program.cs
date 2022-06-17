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
var host = builder.Configuration.GetValue<string>("DefaultSqlHost");
connectionString = connectionString.Replace("[HOST]", host);
//var port = builder.Configuration.GetValue<int>("DefaultSqlPort");
//connectionString = connectionString.Replace("[PORT]", port.ToString());
Console.WriteLine($"!!!! Dikkat !!!!! Connecting String: {connectionString} ");
builder.Services.AddDbContext<BookStoreDbContext>(conf => conf.UseSqlServer(connectionString, db=>db.MigrationsAssembly("BookStore.DataAccess")));
builder.Services.AddScoped<IBookRepository, EFBookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddResponseCaching();
builder.Services.AddMemoryCache();
//builder.Services.AddDistributedSqlServerCache(opt =>
//{
//    opt.ConnectionString = builder.Configuration.GetConnectionString("cacheDb");
//    opt.SchemaName = "dbo";
//    opt.TableName = "TestCache";
  
//});


var app = builder.Build();

var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<BookStoreDbContext>();
CreateDatabase.Create(dbContext);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseResponseCaching();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


public partial class Program
{

}