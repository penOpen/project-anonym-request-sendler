namespace AnonymRequest.Storage.Entities
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; } //
        public int id_ticketmod { get; set; } // 
        public int id_ticketinfo { get; set; }//
        

        [ForeignKey(nameof(id_ticketmod))]
        public virtual Modticket Modticket { get; set; }

        [ForeignKey(nameof(id_ticketinfo))]
        public virtual TicketInfo Ticketinfo { get; set; }

    }
}