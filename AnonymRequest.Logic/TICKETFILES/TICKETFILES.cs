
namespace AnonymRequest.Logic.TICKETFILES
{
    public class TICKETFILES : ITICKETFILES
    {
        private readonly Context _context;

        public TICKETFILES(Context context)
        {
            _context = context;
        }

        public async Task Bind_Ticket_File(int id_file, int id_ticket)
        {
            var new_bind = new TicketFiles{file_id = id_file, ticketinfo_id = id_ticket };
            _context.Add(new_bind);
            await _context.SaveChangesAsync();
        }
    }
}