using MediatR;
using PetStoreApp.Application.Users.Services;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Queries;

public class GetUserListHandler : IRequestHandler<GetUserListQuery, List<User>>
{
    private readonly IUserService _userService;

    public GetUserListHandler(IUserService userService)
    {
        _userService = userService;
    }
    public Task<List<User>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
    {
        return Task.FromResult(_userService.GetUsers());
    }
}