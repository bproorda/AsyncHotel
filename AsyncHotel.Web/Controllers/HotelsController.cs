using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsyncHotel.Web.Models;
using AsyncHotel.Web.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsyncHotel.Web.Controllers
{
    public class HotelsController : Controller
    {
        private readonly IHotelService hotelService;

        public HotelsController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        // GET: Hotels
        public async Task<ActionResult> Index()
        {
           

            var hotels = await hotelService.GetAllHotels();

            //wanted to try out the orderby
            //return View(hotels.OrderBy(hotel => hotel.Name));
            return View(hotels);
        }

        // GET: Hotels/Details/5
        public async Task<ActionResult> Details(int id)
        {
            //var hotelDetailed = new Hotel {Id = id, Name = "DetailedHotel", City = "Houghton", State = "Michigan" };
            var hotelDetailed = await hotelService.GetOneHotel(id);
            return View(hotelDetailed);
        }

        // GET: Hotels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Hotels/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hotels/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Hotels/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Hotels/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Hotels/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}