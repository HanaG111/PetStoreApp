using MediatR;
using PetStoreApp.Application.Users.Services;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Commands;

public class CreateUserHandler : IRequestHandler<CreateUserCommand, User>
{
    private readonly IUserService _userService;

    public CreateUserHandler(IUserService userService)
    {
        _userService = userService;
    }
    public async Task<User> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await Task.FromResult(_userService.CreateUser(request));
    }
}