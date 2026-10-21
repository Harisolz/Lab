var builder = WebApplication.CreateBuilder(args);

// Đăng ký MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình xử lý lỗi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// HTTPS
app.UseHttpsRedirection();

// Cho phép truy cập CSS, JS, hình ảnh
app.UseStaticFiles();

// Routing
app.UseRouting();

// Authorization
app.UseAuthorization();

// Route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}"
);

app.Run();