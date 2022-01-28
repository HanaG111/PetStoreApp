﻿namespace PetStoreApp.Domain.Models;
public class User : UserEntity
{
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }

    public enum Status
    {
        Active,
        Inactive
    }
}