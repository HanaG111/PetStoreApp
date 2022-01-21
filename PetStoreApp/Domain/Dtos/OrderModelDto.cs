using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Domain.Dtos;
public class OrderModelDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    [Range(0, 10)]
    public int PetId { get; set; }
    
    [Required(ErrorMessage = "The field {0} is required")]
    [Range(0, 10)]
    public int Quantity { get; set; }
    
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50)]
    public string ShipDate { get; set; }
    
    [StringLength(50)]
    [Required(ErrorMessage = "The field {0} is required")]
    public string Status { get; set; }
    
    [Required(ErrorMessage = "The field {0} is required")]
    public bool Complete { get; set; }
}