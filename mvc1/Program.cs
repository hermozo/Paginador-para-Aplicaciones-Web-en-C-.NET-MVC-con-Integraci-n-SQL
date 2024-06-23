using Microsoft.EntityFrameworkCore;
using mvc1;
using mvc1.Interfaces;
using mvc1.Repository;
using mvc1.Service;
using System;

var builder = WebApplication.CreateBuilder(args);
string conx = builder.Configuration.GetConnectionString("DefaultConnectionString")!;
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDBContext>(options => {
    options.UseSqlServer(conx);
});
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IProductoService, ProductoService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
