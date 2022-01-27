using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Services;
public interface IUserService
{
    List<User> GetUsers(); 
    User CreateUser(int userId, UserDto userDto);
    User EditUser(int userId, UserDto userDto);
    User DeleteUser(User user);
}