using Domain.Entities;

namespace Domain.DTO
{
    public class AuthUserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tag { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Description { get; set; }
        public string GenresReaded { get; set; }

        public AuthUserDto(CommonUser proto)
        {
            Id = proto.Id;

            Name = proto.Name;

            Tag = proto.Tag;

            Email = proto.Email;

            Password = proto.Password;

            Description = proto.Description;

            GenresReaded = proto.GenresReaded;
        }
    }
}