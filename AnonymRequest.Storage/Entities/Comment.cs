namespace AnonymRequest.Storage.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; } // ���������� ����
        bool is_mod { get; set; } // �����/������������

        string text { get; set; } // ����� ��������

        long time { get; set; } // ����� ��������� �������� 
        


    }
    //
}