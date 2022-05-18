using AnonymRequest.Storage;
using Microsoft.EntityFrameworkCore;
using AnonymRequest.Logic.FILES;
using AnonymRequest.Logic.TICKETGUID;
using AnonymRequest.Logic.TICKETINFO;
using AnonymRequest.Logic.TICKETS;
using AnonymRequest.Logic.TICKETTOKEN;
using AnonymRequest.Logic;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AnonymRequest.Logic.COMMENT;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();
services.AddScoped<IFILES, FILES>();
services.AddScoped<ITICKETGUID, TICKETGUID>();
services.AddScoped<ITICKETINFO, TICKETINFO>();
services.AddScoped<ICOMMENT, COMMENT>();
services.AddScoped<ITICKETS, TICKETS>();
services.AddScoped<ITICKETTOKEN, TICKETTOKEN>();
;//Add Database Context
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
services.AddDbContext<Context>(param => param.UseSqlServer(connectionString));
services.AddHttpClient();

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
    pattern: "{controller=Home}/{action=index}/{id?}");

app.Run();
