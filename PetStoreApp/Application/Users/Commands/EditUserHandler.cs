using MediatR;
using PetStoreApp.Application.Users.Services;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Commands;

public class EditUserHandler : IRequestHandler<EditUserCommand, User>
{
    private readonly IUserService _userService;
    public EditUserHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<User> Handle(EditUserCommand request, CancellationToken cancellationToken)
    {
        var user = _userService.GetUsers().FirstOrDefault(x => x.UserId == request.UserId);

        if (user == null)
        {
            throw new ApplicationException("No User with this Id");
        }
        return await Task.FromResult(_userService.EditUser(request.UserId, request.UserDto));
    }
}