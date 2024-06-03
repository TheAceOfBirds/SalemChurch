using BlankMVC.Repositories;
using BlankMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;

namespace BlankMVC.Controllers
{
    public class PetController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<PetController> _logger;
        GeneralRepo _genRepo;
        private PetService petService;
        public PetController(ILogger<PetController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
            _genRepo = new GeneralRepo(Configuration.GetConnectionString("SQLiteConnectionString"));
            _genRepo.InitializeTypes();
            petService = new PetService(configuration);
        }
        public IActionResult Index()
        {
            return View(petService.getPetsList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            var model = new Pet { AvailableTypes = GlobalVariables.Types };
            return View(model);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Pet pet = petService.getPetById(id).Result;
            pet.AvailableTypes = GlobalVariables.Types;
            return View(pet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind("Id","Name","Type","Birthday","OwnerEmail","Fixed", "AvailableTypes")] Pet pet)
        {
            if (pet.Birthday > DateTime.Now)
            {
                ModelState.AddModelError("Birthday", "Birthday cannot be greater then today.");
            }
            if (ModelState.IsValid)
            {
                petService.createNewPet(pet);
                return RedirectToAction("Index");
            }
            return View(pet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id", "Name", "Type", "Birthday", "OwnerEmail", "Fixed", "AvailableTypes")] Pet pet)
        {
            if (pet.Birthday > DateTime.Now)
            {
                ModelState.AddModelError("Birthday", "Birthday cannot be greater then today.");
            }
            if (ModelState.IsValid)
            {
                petService.updatePet(pet);
                return RedirectToAction("Index");
            }
            return View(pet);
        }
        public ActionResult Delete(int id)
        {
            petService.deletePet(id);
            return RedirectToAction("Index");
        }
    }
}
