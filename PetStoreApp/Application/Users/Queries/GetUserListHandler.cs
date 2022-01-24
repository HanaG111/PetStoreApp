using MediatR;
using PetStoreApp.Application.Users.UserService;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Queries;

public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<UserModel>>
{
    private readonly IUserService _userService;

    public GetUserListHandler(IUserService userService)
    {
        _userService = userService;
    }
    public Task<List<UserModel>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_userService.GetUsers());
    }
}