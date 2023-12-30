using Microsoft.EntityFrameworkCore;
using ReactWebBlogger.Application.DTOs;
using ReactWebBlogger.Application.Mapping;
using ReactWebBlogger.Application.Services;
using ReactWebBlogger.Contracts.Repositories;
using ReactWebBlogger.Contracts.Services;
using ReactWebBlogger.Infrastructure;
using ReactWebBlogger.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Configure DbContext
var localDBConnectionString = builder.Configuration.GetConnectionString("LocalDBConnection");
builder.Services.AddDbContext<LocalDbContext>(options =>
    options.UseSqlite(localDBConnectionString));



builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Configure Repository and Service
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService<BlogDto>, BlogService>();

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
