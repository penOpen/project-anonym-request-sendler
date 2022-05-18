using AnonymRequest.Storage.Entities;
namespace AnonymRequest.Logic.TICKETTOKEN
{
    public class TICKETTOKEN : ITICKETTOKEN
    {
        private readonly Context _context;

        public TICKETTOKEN(Context context)
        {
            _context = context;
        }

        public async Task<string> Create_Ticket_Token(int ticketid, Guid guid)
        {
            var s_guid = System.Convert.ToString(guid);
            int key;
            int.TryParse(string.Join("", s_guid.Where(c => char.IsDigit(c))), out key);
            string s_key = System.Convert.ToString(key);
            var new_ticket_token = new TicketToken{key_token = s_key, ticket_id = ticketid};
            _context.Add(new_ticket_token);
            await _context.SaveChangesAsync();

            return s_key;

        }
    }
}