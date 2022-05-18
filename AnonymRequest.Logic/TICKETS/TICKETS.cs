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


        public async Task<int> Create_Tickets(string type, int ticket_info_id)
        {
            int id_of_type = _context.Types.OrderByDescending(p => p.Id).LastOrDefault().Id;
            var new_tickets = new Tickets{id_mod = id_of_type, id_ticketinfo = ticket_info_id};
            _context.Add(new_tickets);
            await _context.SaveChangesAsync();
            int id_of_ticket = _context.Types.OrderByDescending(p => p.Id).LastOrDefault().Id;
            return id_of_ticket;

        }
    }
}