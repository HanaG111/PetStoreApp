using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Domain.Dtos;

public class OrderDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    [Range(0, 10)]
    public int PetId { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    [Range(0, 10)]
    public int Quantity { get; set; }

}