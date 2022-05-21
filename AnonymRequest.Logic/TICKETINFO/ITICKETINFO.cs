namespace AnonymRequest.Logic.TICKETINFO
{
    public interface ITICKETINFO
    {
        public  Task<int> Generate_Ticket(js_parsed info);
        public  Task<TicketInfo> Get_TicketInfo(int id_ticket);
        public Task Update_Status(int id_ticket, string new_status);
    }
}