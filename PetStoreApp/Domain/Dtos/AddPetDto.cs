using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Infrastructure.Dtos;

public class AddPetDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    public string PetName { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public string Status { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public string Category { get; set; }
}