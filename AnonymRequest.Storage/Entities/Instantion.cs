namespace AnonymRequest.Storage.Entities;

public class Instantion
{
    [Key]
    public int Id { get; set; } //ID в БД
    public string Name_of_instation { get; set; } //Имя инстанциии в сущности
    public int Agent_of_instation { get; set; } // ID агентов, связанных с Инстанцией

    /*[Required]
    public int RequestId { get; set; }*/ // {???}

    [ForeignKey(nameof(Agent_of_instation))]//Обратиться ко всем cущностям Agent, связанных с данной иснтанцией
    public virtual Agent Agent  { get; set; } // !!!

}
