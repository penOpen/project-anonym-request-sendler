using System.ComponentModel.DataAnnotations.Schema;
namespace AnonymRequest.Storage.Entities

{
    public class TicketFiles
    {
        [Key]
        public int Id { get; set; } // id 


        public int file_id { get; set; } // id файла
        public int ticketinfo_id { get; set; } // 

        [ForeignKey(nameof(file_id))]
        public virtual Files Files { get; set; }

        [ForeignKey(nameof(ticketinfo_id))]
        public virtual TicketInfo Ticketinfo { get; set; }//
    } 
}
