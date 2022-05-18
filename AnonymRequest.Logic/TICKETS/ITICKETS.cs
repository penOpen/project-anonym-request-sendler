namespace AnonymRequest.Logic.TICKETS
{
    public interface ITICKETS
    {
        public Task<int> Create_Tickets(string type, int ticket_info_id); 
    }
}