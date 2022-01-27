﻿using MediatR;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Users.Queries;
public class FindByUsernameQuery : IRequest<User>
{
    public string Username { get; set; }
}
