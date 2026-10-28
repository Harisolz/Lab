var builder = WebApplication.CreateBuilder(args);

// Đăng ký dịch vụ MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Cấu hình xử lý lỗi
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

// Cấu hình middleware
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Route 1: danh sách sinh viên
// URL: /Admin/Student/List
app.MapControllerRoute(
    name: "student-list",
    pattern: "Admin/Student/List",
    defaults: new
    {
        controller = "Student",
        action = "Index"
    });

// Route 2: form thêm sinh viên
// URL: /Admin/Student/Add
app.MapControllerRoute(
    name: "student-add",
    pattern: "Admin/Student/Add",
    defaults: new
    {
        controller = "Student",
        action = "Create"
    });

// Route 3: xử lý gửi form thêm sinh viên
// URL: /Admin/Student/Add/Submit
app.MapControllerRoute(
    name: "student-add-post",
    pattern: "Admin/Student/Add/Submit",
    defaults: new
    {
        controller = "Student",
        action = "Create"
    });

// Route mặc định
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Student}/{action=Index}/{id?}");

app.Run();