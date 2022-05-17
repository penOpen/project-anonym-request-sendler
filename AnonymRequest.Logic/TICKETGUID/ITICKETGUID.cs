namespace AnonymRequest.Logic.TICKETGUID
{
    public interface ITICKETGUID
    {
         public Task<Guid> Generate_Token(int id_ticket);
    }
}