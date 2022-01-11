using PetStoreApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetStoreApp.Presentation.Controllers;



namespace PetStoreApp.Application.DataAccess;

public class DataAccess : IDataAccess
{
    private List<PetModel> pet = new();

    public DataAccess()
    {
        pet.Add(new PetModel { PetId = 1, PetName = "Ice", Category = "Dog", Status = "Available"});
        pet.Add(new PetModel { PetId = 2, PetName = "Donna", Category = "Cat", Status = "Available" });
    }

    public List<PetModel> GetPets()
    {
        return pet;
    }

    public PetModel AddPet(string petName, string  category, string status)
    {
        PetModel p = new() { PetName = petName };
        p.PetId = pet.Max(x => x.PetId) + 1;
        pet.Add(p);
        return p;
    }
}

