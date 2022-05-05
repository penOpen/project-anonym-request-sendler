namespace AnonymRequest.Storage.Entities;
    public class Agent
    {

    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Working_hours { get; set; }
    public string ContactInfo { get; set; }
    public int InstationId { get; set; }

    [ForeignKey(nameof(InstationId))]
    public virtual Instantion Instantion { get; set; }

}

