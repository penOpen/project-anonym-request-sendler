namespace AnonymRequest.Logic.TICKETTOKEN
{
    public interface ITICKETTOKEN
    {
        public  Task<string> Create_Ticket_Token(int ticketid, Guid guid); 
    }
}