using AnonymRequest.Storage.Entities;
using Microsoft.AspNetCore.Mvc;
using AnonymRequest.Logic.TICKETGUID;
using AnonymRequest.Logic.TICKETINFO;
using AnonymRequest.Logic.FILES;
using AnonymRequest.Storage;
using Microsoft.EntityFrameworkCore;
using AnonymRequest.Logic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;

namespace AnonymRequest.Controllers

{
    public class CreateController : Controller
    {
        private readonly ITICKETGUID Ticketguid;
        private readonly ITICKETINFO Ticketinfo;
        private readonly IFILES Files;
        private readonly Context _context;

        public CreateController(ITICKETGUID guid, ITICKETINFO info, IFILES files, Context context)
        {
            Ticketguid = guid;
            Ticketinfo = info;
            Files = files;
            _context = context;
        }

        

        [HttpPost]
        [Route("Create")]
        public async Task Create()
        {

            using HttpClient client = new()
            {
                BaseAddress = new Uri("https://localhost:7194")
            };

            js_parsed? js_file = await client.GetFromJsonAsync<js_parsed>("/Create");
            var files = new js_file();
            files.name = js_file.js_name;
            files.code = js_file.js_code;
            // пытаемся получить данные json
            //var js_file = await _context.ReadFromJsonAsync<js_parsed>();
            Console.WriteLine("Done");
            var id_file = await Files.Push_File(files);
            Console.WriteLine("Done");
            var id_ticket = await Ticketinfo.Generate_Ticket(js_file, id_file);
            Console.WriteLine("Done");
            var Token = await Ticketguid.Generate_Token(id_ticket);
        }

    }
}