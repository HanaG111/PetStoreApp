﻿using System.ComponentModel.DataAnnotations;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Domain.Dtos;

public class PetDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50)]
    public string PetName { get; set; }
}