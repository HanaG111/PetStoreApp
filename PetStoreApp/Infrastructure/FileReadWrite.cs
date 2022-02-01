using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PetStoreApp.Application.Pets.Services;
using PetStoreApp.Domain.Models;

namespace PetStoreApp.Infrastructure;

public class FileReadWrite : IFileReadWrite
{
    private readonly IPetService _petService;
    private readonly IMediator _mediator;

    // static void Read()
    // {
    //     var text = System.IO.File.ReadAllText(@"C:\Users\Hana\RiderProject\PetStoreApp\PetStoreApp\Infrastructure\DbFiles\DbPets.txt");
    //     
    //     System.Console.WriteLine("Contents of WriteText.txt = {0}", text);
    //
    //     var lines = System.IO.File.ReadAllLines(@"C:\Users\Hana\RiderProject\PetStoreApp\PetStoreApp\Infrastructure\DbFiles\DbPets.txt");
    //     
    //     System.Console.WriteLine("Contents of WriteLines2.txt = ");
    //     foreach (var line in lines)
    //     {
    //         // Use a tab to indent each line of the file.
    //         Console.WriteLine("\t" + line);
    //     }
    //
    //     // Keep the console window open in debug mode.
    //     Console.WriteLine("Press any key to exit.");
    //     System.Console.ReadKey();
    // }
    public async Task Write(Pet pet)
    {
        string[] lines =
        {
            "First line", "Second line", "Third line" 
        };
        await File.WriteAllLinesAsync("WriteLines.txt", lines);
    }
}
