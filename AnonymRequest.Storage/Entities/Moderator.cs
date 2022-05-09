using System.ComponentModel.DataAnnotations;
namespace AnonymRequest.Storage.Entities;

public class Moderator
{
    [Key]
    public int Id {get; set;} //ID в БД

    [Required]
    public int ModeratorToken {get; set;} //Токен модератора
    pulbic List<int> Users_Id {get; set;} //список всех Users
   
    [ForeignKey(nameof(UserId))] //Доступ к Users
    public virtual User User {get; set;}

}
