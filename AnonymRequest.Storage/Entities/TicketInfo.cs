using System;
namespace AnonymRequest.Storage.Entities;
public class TicketInfo
{   
    [Key]
    public int Id { get; set; } //id жалобы
    int files { get; set; } // id файла
    string description { get; set; } // текст

    [ForeignKey(nameof(files))]
    public virtual Files Files { get; set; }

}