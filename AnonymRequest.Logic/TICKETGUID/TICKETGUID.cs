namespace AnonymRequest.Logic.TICKETGUID
{
    public class TICKETGUID : ITICKETGUID
    {
        private readonly Context _context;

        public TICKETGUID(Context context)
        {
            _context = context;
        }

        public async Task<Guid> Generate_Token(int id_ticket)
        {
            var new_token = System.Guid.NewGuid();
            var push_info = new Ticketguid{token = new_token, id_ticket = id_ticket};
            _context.Ticketguids.Add(push_info);
            await _context.SaveChangesAsync();
            
            return new_token;
        }

    }
}