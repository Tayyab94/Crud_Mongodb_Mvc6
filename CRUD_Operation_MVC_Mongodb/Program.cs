using CRUD_Operation_MVC_Mongodb.Models.DBAccess;
using CRUD_Operation_MVC_Mongodb.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<DemoContext>();
builder.Services.AddScoped<IEmployeeRepositroy, EmployeeRepository>();
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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=EmployeeList}/{id?}");

app.Run();
