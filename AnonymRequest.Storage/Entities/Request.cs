using System.ComponentModel.DataAnnotations.Schema;
namespace AnonymRequest.Storage.Entities;

public class Request
{
    [Key]
    public int Id { get; set; } //ID в БД
    public int InstationId { get; set; } //Внутри сущности хранится ID на Instation в БД

    [Required] //Обязательные поля внутри сущности
    public string Header { get; set;} //Заголовок 
    public string Text { get; set; }  //Текст
    public string Instation { get; set; } //Инстанция в жалобе
    public int UserToken { get; set; } //Ключ для обращения к связанному User
    public int StatusId {get; set;} //Хранить ID на status

    [ForeignKey(nameof(InstationId))] //Внешний ключ для обращения к Instantion
    public virtual Instantion Instantion { get; set; }

    [ForeignKey(nameof(StatusId))] //Внешний ключ для обращения к Status
    public virtual Status Status {get; set;}


}
