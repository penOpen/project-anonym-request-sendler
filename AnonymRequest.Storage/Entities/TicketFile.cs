﻿using System.ComponentModel.DataAnnotations.Schema;
namespace AnonymRequest.Storage.Entities;
public class TicketFiles
{
    [Key]
    public int Id { get; set; } // id 


    public int File_id { get; set; } // id файла
    public int ticketinfo_id { get; set; } // 

    [ForeignKey(nameof(File_id))]
    public virtual Files Files { get; set; }

    [ForeignKey(nameof(ticketinfo_id))]
    public virtual TicketInfo Ticketinfo { get; set; }//
}
