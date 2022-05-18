namespace AnonymRequest.Storage.Entities
{
    public class TicketToken
    {
        [Key]
        public int Id { get; set; }
        //public long lifeend;

        public string key_token { get; set; } 

        public int ticket_id { get; set; }

        [ForeignKey(nameof(ticket_id))]
        public virtual Tickets Ticket { get; set; }//

    }
}