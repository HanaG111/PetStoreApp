using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStoreApp.Application.Models;

public class PetModel
{
    public int PetId { get; set; }
    public string PetName { get; set; }
    public string Category { get; set; } 
    public string Status { get; set; }
}