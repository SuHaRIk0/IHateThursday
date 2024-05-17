using Domain.Entities;
using Web.Models;

public class UserProfileViewModel
{
    public ProfileViewModel Profile { get; set; }
    public List<BookViewModel> Books { get; set; }
}