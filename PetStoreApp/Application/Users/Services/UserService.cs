using MediatR;
using PetStoreApp.Application.Users.Commands;
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
    public User CreateUser(CreateUserCommand request)
    {
        var orders = GetUsers();
        User user = new()
        {
            UserId = _user.Max(x => x.UserId) + 1,
            Username = request.Username,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            Phone = request.Phone,
            Status = request.Status
        };
        _user.Add(user);
        return user;
    }
    public User EditUser(EditUserCommand request)
    {
        User user = new()
        {
            Username = request.Username,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password,
            Phone = request.Phone,
            Status = request.Status
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