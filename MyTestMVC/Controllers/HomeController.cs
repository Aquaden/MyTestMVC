using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyTestMVC.Datas;
using MyTestMVC.Datas.Entities;
using MyTestMVC.Models;
using System.Diagnostics;

namespace MyTestMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public AppDbContext _appDbContext;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger,IMapper mapper,AppDbContext appDbContext)
        {
            _logger = logger;
            _mapper = mapper;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Events()
        {
            var data = _appDbContext.Events.ToList();
            return View(data);
        }
        public IActionResult AddEvent()
        {
            return View();
        }
        public IActionResult AddNewEvent(EventsViewModel model)
        {
            Events evnt = _mapper.Map<Events>(model);
            evnt.CurrentDate = DateTime.Now;
            _appDbContext.Events.Add(evnt);
            _appDbContext.SaveChanges();

            return RedirectToAction("Events");
        }
        public IActionResult EditEvent(int id)
        {
            var data = _appDbContext.Events.Where(x => x.Id == id).FirstOrDefault();
            return View(data);
        }
        public IActionResult UpdateEvent(EventsViewModel model,int id)
        {
            var data = _appDbContext.Events.Where(x => x.Id == id).FirstOrDefault();
            _mapper.Map<EventsViewModel,Events>(model,data);
            _appDbContext.Events.Update(data);
            _appDbContext.SaveChanges();
            return RedirectToAction("Events");
        }
        public IActionResult DeleteEvent(int id)
        {
            var data = _appDbContext.Events.Where(x => x.Id == id).FirstOrDefault();
            _appDbContext.Events.Remove(data);
            _appDbContext.SaveChanges();
            return RedirectToAction("Events");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}