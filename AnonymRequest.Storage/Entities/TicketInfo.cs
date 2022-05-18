using System;
namespace AnonymRequest.Storage.Entities;
public class TicketInfo
{   
    [Key]
    public int Id { get; set; } //id жалобы
    public int files { get; set; } // id файла
    
    public int comment {get; set;} //id of comment
    public string name {get ; set;}
    public string description { get; set; } //text
    
    public string status {get; set;}// status = 0 1 2

    [ForeignKey(nameof(files))]
    public virtual Files Files { get; set; }//

    [ForeignKey(nameof(comment))]
    public virtual Comment Comment { get; set;}

}