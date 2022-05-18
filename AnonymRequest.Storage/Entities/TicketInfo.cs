using System;
namespace AnonymRequest.Storage.Entities;
public class TicketInfo
{   
    [Key]
    public int Id { get; set; } //id жалобы
    public int files_id { get; set; } // id файла
    
    public int comment_id {get; set;} //id of comment
    public string name {get ; set;}
    public string description { get; set; } //text
    
    public string status {get; set;}// status = 0 1 2

    [ForeignKey(nameof(files_id))]
    public virtual Files Files { get; set; }//

    [ForeignKey(nameof(comment_id))]
    public virtual Comment Comment { get; set;}

}