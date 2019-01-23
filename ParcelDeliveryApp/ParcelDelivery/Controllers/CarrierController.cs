using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelDelivery.Models;
using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.BLL.Interfaces;
using X.PagedList;

namespace ParcelDelivery.Controllers
{
    public class CarrierController : Controller
    {
        private readonly ICarrierService _carrierService;
        private readonly IUserService _userService;
        private readonly IFeedBackService _feedbackService;

        public CarrierController(
            ICarrierService carrierService,
            IUserService userService,
            IFeedBackService feedbackService)
        {
            _carrierService = carrierService;
            _userService = userService;
            _feedbackService = feedbackService;
        }

        // GET: Carrier
        public IActionResult Index(int? page)
        {
            int pageSize = 8;
            int pageNumber = (page ?? 1);
            double averageRate = 0;
            int sum = 0;
            
            var carrier = Mapper.Map<IEnumerable<CarrierDto>, IEnumerable<CarrierViewModel>>(_carrierService.GetAll());

            foreach (var item in carrier)
            {
                var rate = _feedbackService.GetAll(x => x.Id == item.Id);
                foreach (var k in rate)
                {
                    sum += k.Rating;
                }
                if (rate.Count() != 0)
                    averageRate = sum / rate.Count();
                ViewData.Add($"{item.Id}", averageRate);
                averageRate = 0;
                sum = 0;
            }

            return View(carrier.ToPagedList(pageNumber, pageSize));
        }

        [Authorize]
        public IActionResult Details(int id)
        {
            var carrier = _carrierService.GetAll().FirstOrDefault(x => x.Id == id);
            if (carrier != null)
            {
                var carrierVM = Mapper.Map<CarrierDto, CarrierViewModel>(_carrierService.GetAll().FirstOrDefault(x => x.Id == id));
                return PartialView("_Details", carrierVM);
            }
            return View("Index");
        }

        [Authorize]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CarrierViewModel carrier)
        {
            var userName = User.Identity.Name;
            var userId = _userService.FindUser(userName).Id;

            if (ModelState.IsValid)
            {
                var registeredCarrier = _carrierService.GetAll(x => x.Name == Mapper.Map<CarrierDto>(carrier).Name);
                if (registeredCarrier.Count() != 0)
                {
                    ModelState.AddModelError("", "The carrier allready exists.");
                }
                else
                {
                    carrier.UserId = userId;
                    _carrierService.Create(Mapper.Map<CarrierDto>(carrier));
                }
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Edit(int id)
        {
            var carrier = _carrierService.GetAll(x => x.Id == id);
            if (carrier != null)
            {
                return PartialView("_Edit", Mapper.Map<IEnumerable<CarrierDto>, CarrierViewModel>(_carrierService.GetAll(x => x.Id == id)));
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CarrierViewModel carrier)
        {
            await _carrierService.UpdateAsync(Mapper.Map<CarrierDto>(carrier));
            
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var carrier = _carrierService.GetAll(x => x.Id == id);
            if (carrier != null)
            {
                return PartialView("_Delete", Mapper.Map<IEnumerable<CarrierDto>, CarrierViewModel>(_carrierService.GetAll(x => x.Id == id)));
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var carrier = _carrierService.GetAll(x => x.Id == id);

            if (carrier != null)
            {
                await _carrierService.DeleteAsync(id);
            }

            return RedirectToAction("Index");
        }

        //[Authorize]
        //public IActionResult FilteredList()
        //{
        //    double averageRate = 0;
        //    int sum = 0;

        //    var listOfCarriers = (IEnumerable<FilteredListViewModel>)TempData["carriers"];

        //    foreach (var item in listOfCarriers)
        //    {
        //        var rate = _feedbackService.GetProductFeedbacks(item.CarrierId);
        //        foreach (var k in rate)
        //        {
        //            sum += k.Rating;
        //        }
        //        if (rate.Count() != 0)
        //            averageRate = sum / rate.Count();
        //        ViewData.Add($"{item.CarrierId}", averageRate);
        //        averageRate = 0;
        //        sum = 0;
        //    }

        //    return View(listOfCarriers);
        //}
    }
}