namespace AnonymRequest.Storage.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; } // внутренний ключ
        bool is_mod { get; set; } // Модер/пользователь

        string text { get; set; } // текст коммента

        long time { get; set; } // время написания коммента 
        


    }
}