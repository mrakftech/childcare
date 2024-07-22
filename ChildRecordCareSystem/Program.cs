using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ChildRecordCareSystem.Areas.Identity.Data;
using ChildRecordCareSystem.Filters;
using ChildRecordCareSystem.Models;
using Microsoft.AspNetCore.Identity.UI.Services;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ChildRecordCareSystemContextConnection") ?? throw new InvalidOperationException("Connection string 'ChildRecordCareSystemContextConnection' not found.");

builder.Services.AddDbContext<ChildRecordCareSystemContext>(options => options.UseSqlServer(connectionString));

 builder.Services.AddIdentity<ChildRecordCareSystemUser, IdentityRole>().AddDefaultTokenProviders()
   .AddEntityFrameworkStores<ChildRecordCareSystemContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<AuthenticationFilter>();
builder.Services.AddHttpContextAccessor();  
builder.Services.AddSession(options =>
    options.IdleTimeout = TimeSpan.FromMinutes(60)
);
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
builder.Services.AddScoped<IEmailSender, EmailSender>();

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
app.UseSession();  
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    // Map route for areas
    endpoints.MapControllerRoute(
        name: "MyArea",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    // Map default route
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");

 
});

app.MapRazorPages();
app.Run();
