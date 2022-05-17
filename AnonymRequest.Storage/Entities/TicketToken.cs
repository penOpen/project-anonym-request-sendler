namespace AnonymRequest.Storage.Entities
{
    public class TicketToken
    {
        [Key]
        public int Id { get; set; }
        public long lifeend; // принимаем время токена

        public string token { get; set; } // токен

        public int ticket_id { get; set; } // id тикета

        [ForeignKey(nameof(ticket_id))]
        public virtual Tickets Ticket { get; set; }

    }
}