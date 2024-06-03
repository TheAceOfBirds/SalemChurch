using BlankMVC.Models.Pets.API;
using BlankMVC.Repositories;
using Newtonsoft.Json.Linq;
using System.Text.Json;

namespace BlankMVC.Services
{
    public class PetService
    {
        IConfiguration _configuration;
        PetRepo _petRepo;
        public PetService(IConfiguration configuration)
        {
            _configuration = configuration;
            _petRepo = new PetRepo(_configuration.GetConnectionString("SQLiteConnectionString"));
        }
        public  List<Pet> getPetsList()
        {
            List<Pet> pets = new List<Pet>();
            pets = _petRepo.getPetList();
            pets.Select(c => { c.AvailableTypes = GlobalVariables.Types; return c; }).ToList();
            return pets;
        }
        public async Task<Pet> getPetById(int id)
        {
            return _petRepo.getPetById(id);
        }
        public bool  createNewPet(Pet pet)
        {
            return _petRepo.insertNewPet(pet);
        }
        public bool updatePet(Pet pet)
        {
            return _petRepo.updatePet(pet);
        }
        public bool deletePet(int id)
        {
            return _petRepo.deletePet(id);
        }
    }
}
