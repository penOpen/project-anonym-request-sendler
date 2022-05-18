namespace AnonymRequest.Logic.TICKETGUID
{
    public class TICKETGUID : ITICKETGUID
    {
        private readonly Context _context;

        public TICKETGUID(Context context)
        {
            _context = context;
        }
        //Generate token(Guid token) in Tokenguids with param ticket_id == id_ticket  and returns this token(type == Guid)
        public async Task<Guid> Generate_Token(int id_ticket)
        {
            var new_token = System.Guid.NewGuid();
            var push_info = new Ticketguid{token = new_token};
            _context.Ticketguids.Add(push_info);
            await _context.SaveChangesAsync();
            
            return new_token;
        }
        //returns id of found ticket by its token (Guid token in class Ticketguid)
        //public async Task<int> Find_Ticket_Guid(Guid m_token)
        //{
        //    var info = await _context.Ticketguids.FindAsync(m_token);
        //    if (info == null)
        //    {
        //        return -1;
        //    }
        //    return info.id_ticket;

        //}

    }
}