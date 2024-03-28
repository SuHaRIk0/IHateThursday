using Domain.Entities;

namespace Domain.DTO
{
    public class CommonUserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public string GenresReaded { get; set; }

        public CommonUserDTO(CommonUser proto) 
        {
            Id = proto.Id;
            Name = proto.Name;
            Tag = proto.Tag;
            Description = proto.Description;
            GenresReaded = proto.GenresReaded;
        }
    }
}
