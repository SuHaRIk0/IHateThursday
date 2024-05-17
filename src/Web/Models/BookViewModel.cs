using Domain.Entities;
using Humanizer.Localisation;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Xml.Linq;

namespace Web.Models
{
    public class BookViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string AuthorName { get; set; }

        public string Picture { get; set; }

        public string Language { get; set; }

        public string Genre { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public BookViewModel()
        {
        }

        public BookViewModel(Book dummy)
        {
            Id = dummy.Id;
            Title = dummy.Title;
            AuthorName = dummy.AuthorName;
            Picture = dummy.Picture;
            Language = dummy.LanguageBook;
            Genre = dummy.Genre;
            Description = dummy.Description;
            Status = dummy.Status;
        }
    }
}