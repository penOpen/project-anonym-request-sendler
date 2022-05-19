namespace AnonymRequest.Storage.Entities
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; } //
        public int id_ticketinfo { get; set; }//
        public Guid token { get; set; }
        public int typeid { get; set; }
        
        [ForeignKey(nameof(typeid))]
        public virtual Types Type { get; set; }

        [ForeignKey(nameof(id_ticketinfo))]
        public virtual TicketInfo Ticketinfo { get; set; }
    }
}