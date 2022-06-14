using Middlewares.Infrastructure;

using Middlewares.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Request, middleware tarafından yakalandı");

//});

//app.UseWelcomePage();

app.Map("/test", testApp => {
    testApp.Run(async (context) =>
    {
        var parameterisExists = context.Request.Query.ContainsKey("id");
        if (parameterisExists)
        {
            var id = int.Parse(context.Request.Query["id"]);
            context.Response.WriteAsync($"{id} id'li ürün test ediliyor....");
        }
        else
        {
            context.Response.WriteAsync("id parametresi eksik");
        }

    });
    
});

/*
 * Gelen request'i denetlemek ve editlemek
 * Response'a müdahale etmek (Redirect)
 * Bazı işlemleri koşula dayalı yapmak (db seçimi vs)
 */

//app.UseMiddleware<IECheckMiddleware>();
//app.UseMiddleware<EditResponseMiddleware>();
//app.UseMiddleware<RedirectToPageMiddleware>();

app.UseCheckBrowserIsIE();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();

