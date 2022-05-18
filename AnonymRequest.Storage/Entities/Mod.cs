namespace AnonymRequest.Storage.Entities
{
    public class Mod
    {
        [Key]
        public int Id { get; set; }//id ������

        public Guid token;// guid ������
        public int avatar { get; set; } //������ �� ������ (id �����)

        [ForeignKey(nameof(avatar))]
        public virtual Files Avatar { get; set; }
        //

    }
}