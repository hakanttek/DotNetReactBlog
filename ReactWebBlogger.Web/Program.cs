using Microsoft.EntityFrameworkCore;
using ReactWebBlogger.Contracts.Repositories;
using ReactWebBlogger.Contracts.Services;
using ReactWebBlogger.Domain.Entities;
using ReactWebBlogger.Infrastructure;
using ReactWebBlogger.Infrastructure.Data;
using ReactWebBlogger.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Configure DbContext
var localDBConnectionString = builder.Configuration.GetConnectionString("LocalDBConnection");
builder.Services.AddDbContext<LocalDbContext>(options =>
    options.UseSqlite(localDBConnectionString));


// Configure Repository and Service
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService, BlogService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
