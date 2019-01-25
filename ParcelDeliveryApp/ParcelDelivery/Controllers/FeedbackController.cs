using AutoMapper;
using ParcelDelivery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParcelDelivery.BLL.Dtos;
using ParcelDelivery.BLL.Interfaces;

namespace ParcelDelivery.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ICarrierService _carrierService;
        private readonly IFeedBackService _feedbackService;

        public FeedbackController(
            ICarrierService carrierService,
            IFeedBackService feedbackService)
        {
            _feedbackService = feedbackService;
            _carrierService = carrierService;
        }

        public async Task<IActionResult> CarrierFeedbacks(int id)
        {
            var carrier = await _carrierService.GetAsync(x => x.Id == id);
            var feedBacks = Mapper.Map<IEnumerable<FeedbackDto>, IEnumerable<FeedbackViewModel>>(_feedbackService.GetAll(x => x.CarrierId == carrier.Id));
            return View(feedBacks);
        }

        public IActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FeedbackViewModel feedback, int carrierId)
        {
            if (ModelState.IsValid)
            {
                feedback.CarrierId = carrierId;
                feedback.Date = DateTime.Now;
                await _feedbackService.Create(Mapper.Map<FeedbackDto>(feedback));
            }
            return RedirectToAction("CarrierFeedbacks", "Feedback", new { id = carrierId});
        }

        [Authorize]
        public IActionResult Delete(int id)
        {
            var feedBack = _feedbackService.GetAll(x => x.Id == id);
            if (feedBack != null)
            {
                return PartialView("_Delete", Mapper.Map<FeedbackDto, FeedbackViewModel>(_feedbackService.GetAll(x => x.Id == id).FirstOrDefault()));
            }
            return View("CarrierFeedbacks");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteRecord(int id)
        {
            var feedBack = await _feedbackService.GetAsync(x => x.Id == id);

            if (feedBack != null)
            {
                await _feedbackService.DeleteAsync(id);
            }

            return RedirectToAction("CarrierFeedbacks", "Feedback", new { id = feedBack?.CarrierId });
        }
    }
}