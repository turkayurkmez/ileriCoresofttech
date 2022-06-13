using LifeCycleOfDependencyInjection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LifeCycleOfDependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingletonGuidGenerator _singletonGuidGenerator;
        private readonly IScopedGuidGenerator _scopedGuidGenerator;
        private readonly ITransientGuidGenerator _transientGuidGenerator;
        private readonly GuidService guidService;

        public HomeController(ILogger<HomeController> logger, ISingletonGuidGenerator singletonGuidGenerator, IScopedGuidGenerator scopedGuidGenerator, ITransientGuidGenerator transientGuidGenerator, GuidService guidService)
        {
            _logger = logger;
            _singletonGuidGenerator = singletonGuidGenerator;
            _scopedGuidGenerator = scopedGuidGenerator;
            _transientGuidGenerator = transientGuidGenerator;
            this.guidService = guidService;


        }

        public IActionResult Index()
        {
            ViewBag.Singleton = _singletonGuidGenerator.GuidValue;
            ViewBag.Scoped = _scopedGuidGenerator.GuidValue;
            ViewBag.Transient = _transientGuidGenerator.GuidValue;

            ViewBag.SSingleton = guidService._singletonGuidGenerator.GuidValue;
            ViewBag.SScoped = guidService._scopedGuidGenerator.GuidValue;
            ViewBag.STransient = guidService._transientGuidGenerator.GuidValue;
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}