using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.UserService;
public interface IUserService
{
    List<UserModel> GetUsers(); 
    UserModel CreateUser(int userId, UserModelDto userDto);
    UserModel EditUser(int userId, UserModelDto userDto);
    UserModel DeleteUser(UserModel user);
}