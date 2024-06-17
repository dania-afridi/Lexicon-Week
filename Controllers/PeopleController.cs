using Assignment_01.Models.Entities;
using Assignment_01.Models.Services;
using Assignment_01.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Assignment_01.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPeopleService peopleService;
        public PeopleController (IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }
        
        //---------- FOR People Home view -------------//
        public IActionResult Index(string searchWord)
        {
            var person = String.IsNullOrEmpty(searchWord)? peopleService.All() : peopleService.Search(searchWord);

            return View(person);
        }
        public ActionResult Details(int id) 
        {
            var person = peopleService.SearchById(id);                         
            return View(person);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            peopleService.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonViewModel personModel)
        {
            if(ModelState.IsValid) 
            {
                var person = new Person
                {
                    Name = personModel.Name,
                    City = personModel.City,
                    PhoneNumber = personModel.PhoneNumber
                };
                var peopleViewModel = new PeopleViewModel();
                if(peopleViewModel.People == null)
                {
                    peopleViewModel.People = new List<Person>();

                }
                peopleViewModel.People.Add(person);
                
            }
            return View(personModel);
          
        }
    }

    internal class HttpStatusCodeResult : ActionResult
    {
        private HttpStatusCode badRequest;

        public HttpStatusCodeResult(HttpStatusCode badRequest)
        {
            this.badRequest = badRequest;
        }
    }
}
