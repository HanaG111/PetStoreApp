using System.ComponentModel.DataAnnotations;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Domain.Dtos;

public class PetDto
{
    [Range(0, 10)]
    [Required(ErrorMessage = "The field {0} is required")]
    public string PetName { get; set; }
}