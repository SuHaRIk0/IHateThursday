using Domain.Entities;

namespace Domain.DTO
{
    public class BookDto
    {
<<<<<<< HEAD
        public int Id { get; set; }
=======
        //public int Id { get; set; }
>>>>>>> origin/third_block
        public string AuthorName { get; set; }
        public string Title { get; set; }
        public string Picture { get; set; }
        public string LanguageBook { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public string Status { get; set; }

<<<<<<< HEAD
        public BookDto(Book book)
        {
            Id = book.Id;
=======
        public BookDto(Book book) 
        {
            //Id = book.Id;
>>>>>>> origin/third_block
            AuthorName = book.AuthorName;
            Title = book.Title;
            Picture = book.Picture;
            LanguageBook = book.LanguageBook;
            Description = book.Description;
            Genre = book.Genre;
            Status = book.Status;
        }
    }
<<<<<<< HEAD
}
=======
}
>>>>>>> origin/third_block
