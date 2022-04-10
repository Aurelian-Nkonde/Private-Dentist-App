using System;
using Microsoft.AspNetCore.Mvc;
using DentistApp.Models;
using DentistApp.Data;


namespace DentistApp.Controllers
{
    public class BookingController : Controller
{
    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Booking()
    {
        return View();
    }

    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Booking(Appointment booking)
    {
        if(ModelState.IsValid)
        {
            _context.appointments.Add(booking);
            _context.SaveChanges();
            return RedirectToAction("DoneBooking");
        }
        return View(booking);
    }


    public IActionResult DoneBooking()
    {
        return View();
    }


}

}