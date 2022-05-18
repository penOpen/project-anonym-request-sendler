namespace AnonymRequest.Storage.Entities
{
    public class CommentFiles
    {
        [Key]
        public int Id { get; set; }
        public int comment_id { get; set; } // id ��������
        public int file_id { get; set; } // id �����

        [ForeignKey(nameof(comment_id))]
        public virtual Comment Comment { get; set; }

        [ForeignKey(nameof(file_id))]
        public virtual Files File { get; set; }  
        

    }
    //
}