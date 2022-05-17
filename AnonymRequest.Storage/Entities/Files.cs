namespace AnonymRequest.Storage.Entities;
    public class Files
    {
        [Key]
        public int Id { get; set; }// id файла
        string Name { get; set; }// имя файла
        string uri { get; set; } // uri файла
}

