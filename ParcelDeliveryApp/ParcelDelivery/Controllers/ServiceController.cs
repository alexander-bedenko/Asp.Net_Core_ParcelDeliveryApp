using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.BLL.Interfaces;
using ParcelDelivery.Models;
using ParcelDelivery.Extensions;

namespace ParcelDelivery.Controllers
{
    [Authorize]
    public class ServiceController : Controller
    {
        private readonly ICarrierService _carrierService;
        private readonly IServiceService _serviceService;

        public ServiceController(
            IServiceService serviceService, 
            ICarrierService carrierService)
        {
            _carrierService = carrierService;
            _serviceService = serviceService;
        }

        // GET: Service
        public async Task<IActionResult> Index(int id)
        {
            var carrier = await _carrierService.GetAsync(x => x.Id == id);
            var services = Mapper.Map<IEnumerable<ServiceDto>, IEnumerable<ServiceViewModel>>(_serviceService.GetAll(x => x.CarrierId == carrier.Id));
            return View(services);
        }

        [Authorize]
        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ServiceViewModel service, int carrierId)
        {
            if (ModelState.IsValid)
            {
                service.CarrierId = carrierId;
                await _serviceService.Create(Mapper.Map<ServiceDto>(service));
            }

            return RedirectToAction("Index", "Service", new { id = carrierId });
        }

        public IActionResult Edit(int id)
        {
            var service = _serviceService.GetAll(x => x.Id == id);
            if (service != null)
            {
                return PartialView("_Edit", Mapper.Map<ServiceDto, ServiceViewModel>(_serviceService.GetAll(x => x.Id == id).FirstOrDefault()));
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceViewModel service)
        {
            await _serviceService.UpdateAsync(Mapper.Map<ServiceDto>(service));
            return RedirectToAction("Index", "Service", new { id = service.CarrierId });
        }

        public IActionResult Delete(int id)
        {
            var service = _serviceService.GetAll(x => x.Id == id);
            if (service != null)
            {
                return PartialView("_Delete", Mapper.Map<ServiceDto, ServiceViewModel>(_serviceService.GetAll(x => x.Id == id).FirstOrDefault()));
            }
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var service = await _serviceService.GetAsync(x => x.Id == id);

            if (service != null)
            {
                await _serviceService.DeleteAsync(id);
            }

            return RedirectToAction("Index", "Service", new {id = service?.CarrierId });
        }

        [Authorize]
        public IActionResult FilterOptions()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult FilterOptions(ServiceViewModel service)
        {
            var listOfCarriers = _serviceService.FilteredList(Mapper.Map<ServiceViewModel, ServiceDto>(service));

            TempData.Put("carriers", Mapper.Map<IEnumerable<FilteredListDto>, IEnumerable<FilteredListViewModel>>(listOfCarriers));

            return RedirectToAction("FilteredList", "Carrier");
        }
    }
}