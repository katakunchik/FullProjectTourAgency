using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourAgency.Areas.Admin.Controllers
{
    public class CountryController : Controller
    {
        private readonly ILocationService _locationService;
        public CountryController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        
        // GET: Admin/Country
        public ActionResult Index(CountrySearchViewModel search, int page = 1, int itemsOnPage = 1)
        {
            var model = _locationService.Countries(page, itemsOnPage, search);
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(CountryCreateViewModel countryModel)
        {
            if(ModelState.IsValid)
            {
                var operationStatus = _locationService.CountryCreate(countryModel);
                if(operationStatus == CountryStatusViewModel.Success)
                    return RedirectToAction("Index");
                else if(operationStatus == CountryStatusViewModel.Dublication)
                    ModelState.AddModelError("", "Країна з даним іменем вже існує");
            }
            return View(countryModel);
        }

        public ActionResult Edit(int id)
        {
            var countryModel = _locationService.GetCountryEditById(id);
            return View(countryModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Edit(CountryEditViewModel countryModel)
        {
            if(ModelState.IsValid)
            {
                var operationStatus = _locationService.CountryEdit(countryModel);
                if (operationStatus == CountryStatusViewModel.Success)
                    return RedirectToAction("Index");
                else if (operationStatus == CountryStatusViewModel.Dublication)
                    ModelState.AddModelError("", "Країна з даним іменем вже існує");
                else if (operationStatus == CountryStatusViewModel.Error)
                    ModelState.AddModelError("", "Помилка редагування");
            }
            return View(countryModel);
        }
    }
}