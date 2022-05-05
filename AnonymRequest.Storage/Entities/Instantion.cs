namespace AnonymRequest.Storage.Entities;

public class Instantion
{
    [Key]
    public int Id { get; set; }
    public string Name_of_instation { get; set; }
    public string Agent_of_instation { get; set; }

    [Required]
    public int RequestId { get; set; }

    [ForeignKey(nameof(RequestId))]
    public virtual Request Request { get; set; }

}
