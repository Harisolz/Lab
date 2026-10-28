
using BTH4.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký dịch vụ MVC
builder.Services.AddControllersWithViews();

// 2. Đăng ký Entity Framework Core với SQL Server
builder.Services.AddDbContext<SchoolContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")
    )
);

var app = builder.Build();

// 3. Cấu hình xử lý lỗi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// 4. Cấu hình Middleware
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// 5. Route danh sách sinh viên (BTH3)
// URL: /Admin/Student/List
app.MapControllerRoute(
    name: "student-list",
    pattern: "Admin/Student/List",
    defaults: new
    {
        controller = "Student",
        action = "Index"
    }
);

// 6. Route form thêm sinh viên (BTH3)
// URL: /Admin/Student/Add
app.MapControllerRoute(
    name: "student-add",
    pattern: "Admin/Student/Add",
    defaults: new
    {
        controller = "Student",
        action = "Create"
    }
);

// 7. Route xử lý POST thêm sinh viên (BTH3)
// URL: /Admin/Student/Add/Submit
app.MapControllerRoute(
    name: "student-add-post",
    pattern: "Admin/Student/Add/Submit",
    defaults: new
    {
        controller = "Student",
        action = "Create"
    }
);

// 8. Route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}"
);

app.Run();
