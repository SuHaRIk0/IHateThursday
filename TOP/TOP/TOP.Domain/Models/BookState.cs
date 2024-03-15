namespace TOP.Models
{
    public class BookState
    {
        public int Id { get; set; }
        public string StateBook { get; set; }
        public bool LikeBook { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public Book Book { get; set; }
        public CommonUser User { get; set; }
    }
}
