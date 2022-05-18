using System;
namespace AnonymRequest.Storage.Entities;
public class TicketInfo
{   
    [Key]
    public int Id { get; set; } //id жалобы
    public int files { get; set; } // id файла
    public string? name {get ; set;}
    public string? description { get; set; } // текст

    [ForeignKey(nameof(files))]
    public virtual Files Files { get; set; }//

}