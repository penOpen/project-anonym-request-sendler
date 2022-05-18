namespace AnonymRequest.Storage.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; } // id in database
        public bool is_mod { get; set; } // bool moderator

        public string text { get; set; } // comment

        public long time { get; set; } // time set for comment
        


    }
    //
}