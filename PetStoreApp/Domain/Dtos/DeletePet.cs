using PetStoreApp.Application.Pets.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace PetStoreApp.Infrastructure.Dtos;
public class DeletePet
{
    [Required(ErrorMessage = "The field {0} is required")]
    public string PetId { get; set; }
}