using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TCompany.Models;
using TCompany.ViewModel;

namespace TCompany.Controllers
{
    public class ToursController : Controller
    {
        private readonly TourContext _context;
        private readonly IWebHostEnvironment _appEnvironment;

        public ToursController(TourContext context,IWebHostEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        // GET: Tours
        public async Task<IActionResult> Index()
        {


            return View((await _context.Tours.ToListAsync()).Select(x =>
            new TourViewModel()
            {
                TourId = x.TourId,
                ToursName = x.ToursName,
                Country = x.Country,
                Description = x.Description,
                DaysCost = x.DaysCost,
                ImgSrc = x.ImgSrc
            }));

        }

        public async Task<IActionResult> GetAll()
        {
            return View((await _context.Tours.ToListAsync()).Select(x =>
            new TourViewModel()
            {
                TourId = x.TourId,
                ToursName = x.ToursName,
                Country = x.Country,
                Description = x.Description,
                DaysCost = x.DaysCost,
                ImgSrc = x.ImgSrc
            }));
        }
        public IActionResult GetId(int id)
        {
            var tour = _context.Tours.Find(id);
            var NewTour = new TourViewModel();

            NewTour.TourId = tour.TourId;
            NewTour.ToursName = tour.ToursName;
            NewTour.Country = tour.Country;
            NewTour.Description = tour.Description;
            NewTour.DaysCost = tour.DaysCost;
            NewTour.ImgSrc = tour.ImgSrc;
            return View(NewTour);
        }

        // GET: Tours/AddOrEdit
        public IActionResult AddOrEdit(int id=0)
        {
            if (id == 0)
                return View(new TourViewModel());
            else
            {
                var tour = _context.Tours.Find(id);
                var NewTour = new TourViewModel();

                NewTour.TourId = tour.TourId;
                NewTour.ToursName = tour.ToursName;
                NewTour.Country = tour.Country;
                NewTour.Description = tour.Description;
                NewTour.DaysCost = tour.DaysCost;
                NewTour.ImgSrc = tour.ImgSrc;
                return View(NewTour);
            }
                
        }

        // POST: Tours/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([FromForm] TourViewModel t)
        {
            

            if (ModelState.IsValid)
            {
                if (t.TourId ==0)
                {
                    var tour = new Tour();
                    tour.TourId = t.TourId;
                    tour.ToursName = t.ToursName;
                    tour.Country = t.Country;
                    tour.Description = t.Description;
                    tour.DaysCost = t.DaysCost;
                    tour.ImgSrc = "/Images/NoImageFound.png";
                    _context.Add(tour);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    var tour = _context.Tours.FirstOrDefault(u => u.TourId == t.TourId);
                    tour.TourId = t.TourId;
                    tour.ToursName = t.ToursName;
                    tour.Country = t.Country;
                    tour.Description = t.Description;
                    tour.DaysCost = t.DaysCost;
                    tour.ImgSrc = t.ImgSrc;

                    _context.Update(tour);
                
                    await _context.SaveChangesAsync();
                   

                }
                if (t.uploadedFile != null)
                {
                    // путь к папке Files
                    string path = "/Images/" + t.uploadedFile.FileName;
                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await t.uploadedFile.CopyToAsync(fileStream);
                    }
                    var tour = _context.Tours.FirstOrDefault(u => u.TourId == t.TourId);
                    tour.ImgSrc =path;
                    _context.Tours.Update(tour);
                    _context.SaveChanges();
                }


            }
             return RedirectToAction(nameof(Index)); ;

        }

        

        

        // GET: Tours/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var tour = await _context.Tours.FindAsync(id);
            _context.Tours.Remove(tour);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

       
    }
}
