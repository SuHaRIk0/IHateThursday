using Domain.Entities;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace Web.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public string GenresReaded { get; set; }
        public ProfileViewModel(CommonUser dummy) 
        {
            Id = dummy.Id;
            Email = dummy.Email;
            Name = dummy.Name;
            Tag = dummy.Tag;
            Description = dummy.Description;
            GenresReaded = dummy.GenresReaded;
        }
    }
}

