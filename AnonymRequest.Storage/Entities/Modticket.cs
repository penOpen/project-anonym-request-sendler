namespace AnonymRequest.Storage.Entities
{
    [Keyless]
    public class Modticket
   {
        public int Id {get; set;}

        public int mod_id {get; set;}

        public int ticket_id {get; set;}

        [ForeignKey(nameof(mod_id))]
        public virtual Mod Mod {get; set;}

        [ForeignKey(nameof(ticket_id))]
        public virtual Tickets Tickets{get; set;}
   }
}
