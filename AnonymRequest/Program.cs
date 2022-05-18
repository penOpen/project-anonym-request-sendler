<<<<<<< Updated upstream
using AnonymRequest.Logic.Users;
=======
using AnonymRequest.Logic.FILES;
using AnonymRequest.Logic.TICKETGUID;
using AnonymRequest.Logic.TICKETINFO;
using AnonymRequest.Logic;
>>>>>>> Stashed changes
using AnonymRequest.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

// Add services to the container.
services.AddControllersWithViews();

//Add Database Context
var connectionString = builder.Configuration.GetConnectionString("DbConnection");
services.AddDbContext<Context>(param => param.UseSqlServer(connectionString));
<<<<<<< Updated upstream
services.AddScoped<IUser, UserLogic>();

=======
services.AddScoped<IFILES, FILES>();
services.AddScoped<ITICKETGUID, TICKETGUID>();
services.AddScoped<ITICKETINFO, TICKETINFO>();
>>>>>>> Stashed changes
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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//app.Run(async (context) =>
//{
//    var response = context.Response;
//    var request = context.Request;
//    if (request.Path == "/api/index")
//    {
//        var message = "Ќекорректные данные";   // содержание сообщени€ по умолчанию
//        try
//        {
//            FILES file = null;
//            TICKETINFO ticket = null;
//            TICKETGUID guid = null;
//            // пытаемс€ получить данные json
//            var js_file = await request.ReadFromJsonAsync<js_parsed>();
//            Console.WriteLine("Done");
//            var id_file = await file.Push_File(js_file.files);
//            Console.WriteLine("Done");
//            var id_ticket = await ticket.Generate_Ticket(js_file, id_file);
//            Console.WriteLine("Done");
//            var Token = await guid.Generate_Token(id_ticket);
//        }
//        catch 
//        {
//            Console.WriteLine("-1");
//        }
//        // отправл€ем пользователю данные
//        await response.WriteAsJsonAsync(new { text = message });
//    }
//    else
//    {
//        response.ContentType = "text/html; charset=utf-8";
//        await response.SendFileAsync("html/index.html");
//    }
//});


