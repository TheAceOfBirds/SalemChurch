using BlankMVC.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlankMVC.Controllers
{
    public class DogController : Controller
    {
        private readonly IConfiguration Configuration;
        private readonly ILogger<DogController> _logger;
        private DogService dogAPIService;
        public DogController(ILogger<DogController> logger, IConfiguration configuration)
        {
            _logger = logger;
            Configuration = configuration;
            dogAPIService = new DogService(configuration);
        }
        public IActionResult Index()
        {
            return View(dogAPIService.getDogBreeds().Result);
        }
    }
}
