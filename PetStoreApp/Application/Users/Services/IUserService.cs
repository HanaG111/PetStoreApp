using PetStoreApp.Application.Users.Commands;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Services;
public interface IUserService
{
    List<User> GetUsers(); 
    User CreateUser(CreateUserCommand request);
    User EditUser(EditUserCommand request);
    User DeleteUser(User user);
}