using Domain.Entities;

namespace Web.Models
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public string GenresReaded { get; set; }
        public ProfileViewModel(CommonUser dummy) 
        {
            Id = dummy.Id;
            Name = dummy.Name;
            Tag = dummy.Tag;
            Description = dummy.Description;
            GenresReaded = dummy.GenresReaded;
        }
    }


}
