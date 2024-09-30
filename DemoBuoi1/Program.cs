using DemoBuoi1.Models;

var builder = WebApplication.CreateBuilder(args);//Tạo ra 1 ứng dụng web

// Add services to the container.
builder.Services.AddControllersWithViews();   //add service .. add cointroiler và view
//sau này khi cần add 1 số services thì add ở đây ( dưới var bulder và treenb var app)
builder.Services.AddTransient<SinhVienDAL>();
var app = builder.Build();   // chạy đối tượng web lên

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection(); // cấu hình điều hướng với https
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
