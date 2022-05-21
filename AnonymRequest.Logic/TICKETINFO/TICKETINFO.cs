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

        //Forms ticket and return it id in Ticketinfo databse
        public async Task<int> Generate_Ticket(js_parsed info)
        {
            var new_ticket = new TicketInfo{name = info.name, description = info.description,  status = "0",};
            _context.Add(new_ticket);
            await _context.SaveChangesAsync();
            var id_ticket = new_ticket.Id;
            
            return id_ticket;
        }

        //find ticket and return class with full info of it from database into class js_convert
        //public async Task<js_convert> Get_TicketInfo(int id_ticket)
        //{
        //    var info = new js_convert();
        //    info = await _context.FindAsync<js_convert>(id_ticket);

        //    return info;
        //}

        public async Task<TicketInfo> Get_TicketInfo(int id_ticket)
        {
            var ticketinfo = await _context.TicketInfos.Where(p => p.Id == id_ticket).FirstOrDefaultAsync();
            return ticketinfo;
        }

        public async Task Update_Status(int id_ticket, string new_status)
        {
            var ticket = await _context.TicketInfos.Where(p => p.Id == id_ticket).FirstOrDefaultAsync();
            ticket.status = new_status;
            await _context.SaveChangesAsync();
        }
    }



}