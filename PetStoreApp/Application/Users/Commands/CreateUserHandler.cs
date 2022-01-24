using MediatR;
using PetStoreApp.Application.Users.UserService;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Commands;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, UserModel>
{
    private readonly IUserService _userService;

    public CreateUserHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<UserModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_userService.CreateUser(request.UserId, request.UserDto));
    }
}