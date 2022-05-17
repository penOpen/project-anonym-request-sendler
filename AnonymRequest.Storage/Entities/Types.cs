namespace AnonymRequest.Storage.Entities
{
    public class Types
    {
        [Key]
        public int Id { get; set; } //id ���� ������

        public string value { get; set; } // �������� ����
        public string description { get; set; } // ��������
       //
    }
}