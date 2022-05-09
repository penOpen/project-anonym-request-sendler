namespace AnonymRequest.Storage.Entities;
    public class Agent
    {

    [Key]
    public int Id { get; set; } // ID в БД
    public string Name { get; set; } //Имя
    public string Working_hours { get; set; } //Часы работы формата: XX:XX - XX:XX
    public string ContactInfo { get; set; } //Номер телефона
    public string ContactMail {get; set; } //Почта
    /*public int InstationId { get; set; }*/ //Связанный ID инстанции. {???}

    /*[ForeignKey(nameof(InstationId))]
    public virtual Instantion Instantion { get; set; }*/ /// {???}

}

