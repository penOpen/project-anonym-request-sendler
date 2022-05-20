using AnonymRequest.Storage;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using AnonymRequest.Logic.FILES;
using AnonymRequest.Logic.TICKETINFO;
using AnonymRequest.Logic.TICKETS;
using AnonymRequest.Logic.TICKETTOKEN;
using AnonymRequest.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AnonymRequest.Logic.COMMENT;
using AnonymRequest.Logic.TICKETFILES;
using AnonymRequest.Logic.MOD;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllersWithViews();
services.AddScoped<IFILES, FILES>();
services.AddScoped<ITICKETINFO, TICKETINFO>();
services.AddScoped<ICOMMENT, COMMENT>();
services.AddScoped<ITICKETS, TICKETS>();
services.AddScoped<ITICKETTOKEN, TICKETTOKEN>();
services.AddScoped<ITICKETFILES, TICKETFILES>();
services.AddScoped<IMOD, MOD>();

//Add Database Context
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
services.AddDbContext<Context>(param => param.UseSqlServer(connectionString));
services.AddHttpClient();
services.AddCors(options =>
    {
        options.AddDefaultPolicy(
            policy =>
            {
                policy.WithOrigins("https://localhost:44401");
                policy.WithHeaders("Content-Type");
            }
            );
    }
);

var app = builder.Build();



// Add services to the container.

builder.Services.AddControllersWithViews();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=index}/{id?}");

app.MapFallbackToFile("index.html");
app.Run();