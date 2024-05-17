using Domain.DTO;
using Domain.Entities;
using Domain.IRepository;

namespace Domain.IService
{
    public interface IProfileService : IService
    {
        Task<bool> EditByIdAsync(int id, CommonUser updatedUser);

        Task<CommonUser?> ShowByIdAsync(int id);

        //Task<ProfileViewModel?> TransformUser(CommonUser updatedUser);
    }
}