using Domain.Entities;

namespace Domain.DTO
{
    public class CommonUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Description { get; set; }
        public string GenresReaded { get; set; }

        public CommonUserDto(CommonUser proto)
        {
            Id = proto.Id;

            Name = proto.Name;

            Tag = proto.Tag;

            Description = proto.Description;

            GenresReaded = proto.GenresReaded;
        }
    }
}