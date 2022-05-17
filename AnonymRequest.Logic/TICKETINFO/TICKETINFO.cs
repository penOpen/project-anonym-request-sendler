using AnonymRequest.Logic.FILES;

namespace AnonymRequest.Logic.TICKETINFO
{
    public class TICKETINFO : ITICKETINFO
    {
        private readonly Context _context;

        public TICKETINFO(Context context)
        {
            _context = context;
        }

        public js_parsed Json_Parse(string json)
        {
           var obj = System.Text.Json.JsonDocument.Parse(json);
           var post_created = System.Text.Json.JsonSerializer.Deserialize<js_parsed>(obj);
           //var new_ticket = new TicketInfo{name = post_created.name, description = post_created.desc, };
           //var id_file = Push_File(post_created);
           return post_created;
        }

        public async Task<int> Generate_Ticket(js_parsed info, int id_file)
        {
            var new_ticket = new TicketInfo{name = info.name, description = info.desc, files = id_file};
            _context.Add(new_ticket);
            var id_ticket = new_ticket.Id;
            await _context.SaveChangesAsync();

            return id_ticket;
        }

    }



}