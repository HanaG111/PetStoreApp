using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Domain.Dtos;
public class OrderModelDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    public int PetId { get; set; }
    
    [Required(ErrorMessage = "The field {0} is required")]
    public int Quantity { get; set; }
    
    [Required(ErrorMessage = "The field {0} is required")]
    public string ShipDate { get; set; }
    
    [Required(ErrorMessage = "The field {0} is required")]
    public string Status { get; set; }
    
    [Required(ErrorMessage = "The field {0} is required")]
    public bool Complete { get; set; }
}