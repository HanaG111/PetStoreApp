using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.UserService;
public class UserService : IUserService
{
    private readonly IMediator _mediator;

    private readonly List<UserModel> _user = new();

    public UserService()
    {
        _user.Add(new UserModel {UserId = 1, Username = "hanag", FirstName = "Hana", LastName = "Gicevic", Email = "hanagicevic@gmail.com", Password = "12345678", Phone = "12345678", Status = 0});
    }
    public List<UserModel> GetUsers()
    {
        return _user;
    }
    public UserModel CreateUser(int userId, UserModelDto userDto)
    {
        UserModel user = new()
        {
            UserId = _user.Max(x => x.UserId) + 1,
            Username = userDto.Username,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            Password = userDto.Password,
            Phone = userDto.Phone,
            Status = userDto.Status
        };
        return user;
    }
    public UserModel EditUser(int userId, UserModelDto userDto)
    {
        UserModel user = new()
        {
            Username = userDto.Username,
            FirstName = userDto.FirstName,
            LastName = userDto.LastName,
            Email = userDto.Email,
            Password = userDto.Password,
            Phone = userDto.Phone,
            Status = userDto.Status
        };
        return user;
    }
    public UserModel DeleteUser(UserModel user)
    {
        var users = GetUsers();
        users.Remove(user);
        return user;
    }
}