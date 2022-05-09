using System.ComponentModel.DataAnnotations.Schema;
namespace AnonymRequest.Storage.Entities;

public class User
{
    [Key]
    public int Id { get; set; } //В БД ID позиции у User
    public string Token { get; set; } //Токен внутри сущности в БД
    public int RequestId {get; set; } //Внутри сущности ID на Request в БД
    [ForeignKey(nameof(RequestId))]
    public virtual Request Request {get; set;}//Внутри сущности хранится ключ ID на БД Request
    
}
