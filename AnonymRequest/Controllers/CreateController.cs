using AnonymRequest.Storage.Entities;
using Microsoft.AspNetCore.Mvc;
using AnonymRequest.Logic.TICKETINFO;
using AnonymRequest.Logic.FILES;
using AnonymRequest.Logic.COMMENT;
using AnonymRequest.Logic.TICKETS;
using AnonymRequest.Logic.TICKETTOKEN;
using AnonymRequest.Logic.TICKETFILES;
using AnonymRequest.Storage;
using AnonymRequest.Logic;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Json;
using System.Net;
using AnonymRequest.Models;
using AnonymRequest.Logic.TYPES;

namespace AnonymRequest.Controllers

{
    public class CreateController : Controller
    {
        private readonly ITICKETINFO Ticketinfo;
        private readonly IFILES Files;
        private readonly ICOMMENT Comments;
        private readonly ITICKETS Tickets;
        private readonly ITICKETTOKEN Tickettoken;
        private readonly ITICKETFILES Ticketfiles;
        private readonly ITYPES Types;

        public CreateController( ITICKETINFO info, IFILES files, ICOMMENT comment, ITICKETS ticket, ITICKETTOKEN tickettoken, ITICKETFILES add_Files, ITYPES type)
        {

            Ticketinfo = info;
            Files = files;
            Comments = comment;
            Tickets = ticket;
            Tickettoken = tickettoken;
            Ticketfiles = add_Files;
            Types = type;
        }

        [HttpPost]
        [Route("api/create")]
        public async Task<string> Create([FromBody] CreateRequest _js_file)
        {
            int len = _js_file.Files.Length;
            List<int> id_of_files = new List<int>();

            for (int i = 0; i < len; i++)
            {
                var temp_file = _js_file.Files[i];
                Logic.File file = new Logic.File(temp_file.name, temp_file.code);
                var id_file = await Files.Push_File(file);
                Console.WriteLine(id_file);
                Console.WriteLine(id_of_files);
                id_of_files.Add(id_file);
            }
            var info = new js_parsed(_js_file.Type, _js_file.Name, _js_file.Description);
            var id_ticketinfo = await Ticketinfo.Generate_Ticket(info);
            var type_id = await Types.GetTypeIDByValue(_js_file.Type);

            foreach (var id_file in id_of_files)
            {
                await Ticketfiles.Bind_Ticket_File(id_file, id_ticketinfo);
            }

            var id_tickets = await Tickets.Create_Tickets(id_ticketinfo, type_id);
            var push_token = await Tickettoken.Create_Ticket_Token(id_tickets);
            var guid = await Tickets.GetGuidById(id_tickets);
            var response = new CreateResponse(push_token, guid);
            return response.ToString();
        }


    }
}