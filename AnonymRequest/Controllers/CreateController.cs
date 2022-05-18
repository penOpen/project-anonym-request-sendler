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
        private  js_parsed? _js_file;
        private HttpClient client;
        public CreateController(ITICKETGUID guid, ITICKETINFO info, IFILES files, HttpClient httpClient)
        {
            Ticketguid = guid;
            Ticketinfo = info;
            Files = files;
            client = httpClient;
        }


        [HttpPost]
        [Route("Create")]
        public async Task Create()
        {
            //using HttpClient client = new HttpClient()
            //{
            //    BaseAddress = new Uri("https://localhost:7194")
            //}
            //;
            //using HttpClient client = new HttpClient();
            var _js_file = await client.GetFromJsonAsync<js_parsed>("https://localhost:7194/Create", default);
            Console.WriteLine("Done");
            var files = new js_file();
            files.name = _js_file.js_name;
            files.code = _js_file.js_code;

            Console.WriteLine("Done");
            var id_file = await Files.Push_File(files);
            Console.WriteLine("Done");
            var id_ticket = await Ticketinfo.Generate_Ticket(_js_file, id_file);
            Console.WriteLine("Done");
            var Token = await Ticketguid.Generate_Token(id_ticket);

        }

    }
}