using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Domain.Dtos;
public class PetModelDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    public string PetName { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public string Status { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    public string Category { get; set; }
}