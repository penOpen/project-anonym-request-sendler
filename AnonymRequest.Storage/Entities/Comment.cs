namespace AnonymRequest.Storage.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; } // ���������� ����
        public bool is_mod { get; set; } // �����/������������

        public string text { get; set; } // ����� ��������

        public long time { get; set; } // ����� ��������� �������� 
        


    }
    //
}