using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Domain.Dtos;
public class PetDto
{
    [Range(0, 10)]
    [Required(ErrorMessage = "The field {0} is required")]
    public string PetName { get; set; }

    [StringLength(50)]
    [Required(ErrorMessage = "The field {0} is required")]
    public string Status { get; set; }

    [StringLength(50)]
    [Required(ErrorMessage = "The field {0} is required")]
    public string Category { get; set; }
}