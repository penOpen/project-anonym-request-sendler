namespace AnonymRequest.Storage.Entities
{
    public class Mod
    {
        [Key]
        public int Id { get; set; }//id ������

        Guid token;// guid ������
        int avatar { get; set; } //������ �� ������ (id �����)

        [ForeignKey(nameof(avatar))]
        public virtual Files Avatar { get; set; }
        //

    }
}