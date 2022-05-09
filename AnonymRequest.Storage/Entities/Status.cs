using System;
namespace AnonymRequest.Storage.Entities;

public class Status
{
    [Key]
    public int Id { get; set; } //ID в БД

    [Required]
    public string Comment { get; set; } //Модератор имеет доступ к этому полю
    public char Condition { get; set; } //Состояние: F - обработано, W - в обработке , N - не начато
    //public int RequestId { get; set; } {???}

    /*[ForeignKey(nameof(RequestId))]
    public virtual Request Request { get; set; } {???} */

}
