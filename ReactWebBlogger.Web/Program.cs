using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ReactWebBlogger.Application;
using ReactWebBlogger.Application.DTOs;
using ReactWebBlogger.Application.Mapping;
using ReactWebBlogger.Application.Services;
using ReactWebBlogger.Contracts.Repositories;
using ReactWebBlogger.Contracts.Services;
using ReactWebBlogger.Infrastructure;
using ReactWebBlogger.Infrastructure.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

// Configure DbContext
var localDBConnectionString = builder.Configuration.GetConnectionString("LocalDBConnection");
builder.Services.AddDbContext<LocalDbContext>(options =>
    options.UseSqlite(localDBConnectionString));

// Add CORS policy
var corsSettings = builder.Configuration.GetSection("Cors").GetChildren().ToDictionary(x => x.Key, x => x.GetSection("Origins").Get<string[]>());

builder.Services.AddCors(options =>
{
    foreach (var policy in corsSettings)
    {
        options.AddPolicy(policy.Key, builder =>
            builder.WithOrigins(policy.Value)
                   .AllowAnyHeader()
                   .AllowAnyMethod());
    }
});

//add Jwt AuthenticationScheme to authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:Issuer"],
    ValidAudience = builder.Configuration["Jwt:Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]??""))
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
{
    // Cookie authentication options
    options.LoginPath = "/api/login/in";
    options.LogoutPath = "/api/login/out";
})
;

builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

// Configure Repository and Service
builder.Services.AddScoped<IBlogRepository, BlogRepository>();
builder.Services.AddScoped<IBlogService<BlogDto>, BlogService>();

builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameService<GameDto>, GameService>();

builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageService<MessageDto>, MessageService>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService<UserDto>, UserService>();

builder.Services.AddScoped < IUserTokenService<UserDto>>(provider => new UserTokenService(
    jwtKey: builder.Configuration["Jwt:Key"]??"",
    jwtIssuer: builder.Configuration["Jwt:Issuer"] ?? "",
    jwtAudience: builder.Configuration["Jwt:Audience"] ?? ""
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Use CORS policy
var corsPolicyName = builder.Configuration.GetValue<string>("CorsPolicy");
app.UseCors(corsPolicyName);

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
