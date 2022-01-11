using System;
using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Infrastructure.Dtos;

public class EditPet
{
    [Key]
    public int PetId { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public string PetName { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public string Status { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public string Category { get; set; }

}