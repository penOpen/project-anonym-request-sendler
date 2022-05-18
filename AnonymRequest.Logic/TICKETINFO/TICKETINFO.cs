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

        //Forms ticket and return it id in Ticketinfo databse
        public async Task<int> Generate_Ticket(js_parsed info, int id_file, int id_comment)
        {
            var new_ticket = new TicketInfo{ files_id = id_file, comment_id = id_comment, name = info.name, description = info.description,  status = "0",};
            _context.Add(new_ticket);
            await _context.SaveChangesAsync();
            int id_ticket = _context.TicketInfos.OrderByDescending(p => p.Id).LastOrDefault().Id;
            
            return id_ticket;
        }


        //find ticket and return class with full info of it from database into class js_convert
        public async Task<js_convert> Get_TicketInfo(int id_ticket)
        {
            var info = new js_convert();
            info = await _context.FindAsync<js_convert>(id_ticket);

            return info;
        }


    }



}