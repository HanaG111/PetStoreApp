using PetStoreApp.Domain.Models;

namespace PetStoreApp.Application.Commands;

public class EditPetCommand
{
    public int PetId { get; set; }
    public string PetName { get; set; }
    public string Category { get; set; }
    public string Status { get; set; }
}