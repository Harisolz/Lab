using Microsoft.EntityFrameworkCore;
using PhamSonHai223630687.Models;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký MVC
builder.Services.AddControllersWithViews();

// Đăng ký kết nối SQL Server
builder.Services.AddDbContext<QLTaiSanContext>(options =>
    options.UseSqlServer(
        "Server=.\\SQLEXPRESS;Database=QLTaiSan;Trusted_Connection=True;TrustServerCertificate=True;"));

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