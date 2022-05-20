using AnonymRequest.Storage.Entities;
namespace AnonymRequest.Logic.TICKETS
{
    public class TICKETS : ITICKETS
    {
        private readonly Context _context;

        public TICKETS(Context context)
        {
            _context = context;
        }


        public async Task<int> Create_Tickets(int ticket_info_id, int type_id)
        {   
            Guid token =  Guid.NewGuid();
            var new_tickets = new Tickets{id_ticketinfo = ticket_info_id, token = token, typeid = type_id};
            _context.Add(new_tickets);
            await _context.SaveChangesAsync();
            
            var id_of_ticket = new_tickets.Id;

            return id_of_ticket;

        }

        public async Task<string>GetGuidById(int id)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(p => p.Id == id);
            return ticket.token.ToString();
        }

        public async Task<int> GetTicketByGuid(string guid)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(p => p.token.ToString() == guid);
            if (ticket == null) return -1;
            return ticket.Id;
        }

        public async Task<Tickets> GetTicketByID(int ticket_id)
        {
            var ticket = await _context.Tickets.OrderBy(p=>p.id_ticketinfo == ticket_id).FirstOrDefaultAsync();
            return ticket;
        }

        public async Task<int> GetTicketInfoIDbyGUID(string guid)
        {
            var ticket = await _context.Tickets.FirstOrDefaultAsync(p => p.token.ToString() == guid);
            if (ticket == null) return -1;
            return ticket.id_ticketinfo;
        }

    }
}