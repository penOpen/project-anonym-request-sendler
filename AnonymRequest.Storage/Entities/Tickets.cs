namespace AnonymRequest.Storage.Entities
{
    public class Tickets
    {
        [Key]
        public int Id { get; set; } //
        public int id_mod { get; set; } // 
        public int id_ticketinfo { get; set; }//
        

        [ForeignKey(nameof(id_mod))]
        public virtual Mod Mod { get; set; }

        [ForeignKey(nameof(id_ticketinfo))]
        public virtual TicketInfo Ticketinfo { get; set; }

    }
}