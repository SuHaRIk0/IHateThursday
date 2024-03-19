namespace Domain.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string GenresWriting { get; set; }
        public string LanguageWriting { get; set; }
        public string Nationality { get; set; }
        public int UserId { get; set; }
        public CommonUser User { get; set; }
    }
}
