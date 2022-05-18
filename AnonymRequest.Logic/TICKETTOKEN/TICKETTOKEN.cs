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

        public async Task<string> Create_Ticket_Token(int ticketid)
        {
          
        var token = TokenGen(10);
        var new_tickettoken = new TicketToken{key_token = token, ticket_id = ticketid};
        _context.Add(new_tickettoken);
        await _context.SaveChangesAsync();
        return token; 
        }
        private string TokenGen(int length)
        {
        string token = "";
        var r = new Random();
        for ( int k = 0; k < length; k++ )
        {
            switch (r.Next(1, 3))
            {
                case 1:
                    token += (char)r.Next(97, 123);
                    break;
                case 2:
                    token += (char)r.Next(65, 91);
                    break;
            }
        }
        return token;
    }
}
}