using PetStoreApp.Application.Models;
using MediatR;


namespace PetStoreApp.Application.Commands;

    public record AddPetCommand(string PetName, string Category, string Status) : IRequest<PetModel>;

    // public class InsertPetCommandClass : IRequest<PetModel>
    // {
    //     public string PetName { get; set; }
    //   
    //
    //    public InsertPetCommandClass(string petName)
    //    {
    //       PetName = petName;
    //     
    //    }
    // }
