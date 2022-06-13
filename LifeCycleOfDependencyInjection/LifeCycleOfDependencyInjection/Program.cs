using LifeCycleOfDependencyInjection.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ISingletonGuidGenerator, SingletonGuidGenerator>();
builder.Services.AddScoped<IScopedGuidGenerator, ScopeguidGenerator>();
builder.Services.AddTransient<ITransientGuidGenerator, TransientGuidGenerator>();
builder.Services.AddScoped<GuidService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


var singletonGuid = app.Services.GetRequiredService<ISingletonGuidGenerator>();
Console.WriteLine($"guid: {singletonGuid.GuidValue} " );


var transientGuid = app.Services.GetRequiredService<ITransientGuidGenerator>();
Console.WriteLine($"guid: {transientGuid.GuidValue} ");


var scopedGuid = app.Services.CreateScope().ServiceProvider.GetRequiredService<IScopedGuidGenerator>();
Console.WriteLine($"ilk scoped guid: {scopedGuid.GuidValue} ");

var scopedGuid2 = app.Services.CreateScope().ServiceProvider.GetRequiredService<IScopedGuidGenerator>();
Console.WriteLine($"2. scoped guid: {scopedGuid2.GuidValue} ");


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
