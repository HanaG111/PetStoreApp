using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Domain.Dtos;
public class UserDto
{
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50)]
    public string Username { get; set; }
    
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50)]
    public string LastName { get; set; }
    
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50)]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50)]
    public string Password { get; set; }
    
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50)]
    public string Phone { get; set; }
    [Required(ErrorMessage = "The field {0} is required")]
    [StringLength(50)]
    public int Status { get; set; }
}