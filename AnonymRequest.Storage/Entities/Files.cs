namespace AnonymRequest.Storage.Entities
{

    public class Files
    {
        [Key]
        public int Id { get; set; }// id файла
        public string Name { get; set; }// имя файла
        public string url { get; set; } // uri файла
                                        //
    }
}

