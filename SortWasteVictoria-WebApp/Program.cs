using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SortWasteVictoria_WebApp.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SortWasteVictoria_WebAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SortWasteVictoria_WebAppContext") ?? throw new InvalidOperationException("Connection string 'SortWasteVictoria_WebAppContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{ 
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<SortWasteVictoria_WebAppContext>();
    //DataInitializer.deleteBinItem(context);
/*    DataInitializer.SeedBinData(context);
    DataInitializer.SeedGarbageData(context);*/
    

}
    
/*using (var scope = app.Services.CreateScope())
{ 
    var services = scope.ServiceProvider;
    DataInitializer.SeedData(services);
}*/

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
    }
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
