using MediatR;
using PetStoreApp.Domain.Dtos;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Services;
public class UserService : IUserService
{
    private readonly IMediator _mediator;

    private readonly List<User> _user = new();

    public UserService()
    {
        _user.Add(new User {UserId = 1, Username = "hanag", FirstName = "Hana", LastName = "Gicevic", Email = "hanagicevic@gmail.com", Password = "12345678", Phone = "12345678", Status = 0});
    }
    public List<User> GetUsers()
    {
        return _user;
    }
    public User CreateUser(int userId, UserDto userDto)
    {
        User user = new()
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
    public User EditUser(int userId, UserDto userDto)
    {
        User user = new()
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
    public User DeleteUser(User user)
    {
        var users = GetUsers();
        users.Remove(user);
        return user;
    }
}