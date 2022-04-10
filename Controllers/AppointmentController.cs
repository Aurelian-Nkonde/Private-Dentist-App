using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DentistApp.Models;
using System.Collections.Generic;
using DentistApp.Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;


namespace DentistApp.Controllers
{
    public class AppointmentController : Controller
{
    private readonly ApplicationDbContext _context;

    public AppointmentController(ApplicationDbContext context)
    {
        _context = context;
    }


    [Authorize]
    public IActionResult Main()
    {
        IEnumerable<Appointment> appointments = _context.appointments;
        return View(appointments);
    }


    [Authorize]
    public IActionResult DetailBooking(int? id)
    {
        if (id == null && id == 0)
        {
            return NotFound();
        }
        var booking = _context.appointments.Find(id);
        if (booking == null)
        {
            return NotFound();
        }
        return View(booking);
    }


    [Authorize]
    [HttpGet]
    public IActionResult DeleteBooking(int? id)
    {
        if (id == 0 && id == null)
        {
            return NotFound();
        }
        var bookingToDelete = _context.appointments.Find(id);
        if (bookingToDelete == null)
        {
            return NotFound();
        }
        return View(bookingToDelete);
    }


    [Authorize]
    [HttpPost]
    public IActionResult DeleteBookings(int? id)
    {
        if(id == null && id == 0)
        {
            return NotFound();
        }
        var dataToDelete = _context.appointments.Find(id);
        if (dataToDelete != null)
        {
            _context.appointments.Remove(dataToDelete);
            _context.SaveChanges();
            return RedirectToAction("Main");
        }
        return View();
    }


    [Authorize]
    [HttpGet]
    public IActionResult UpdateBooking(int? id)
    {
        if (id == null && id == 0)
        {
            return NotFound();
        }
        var booking = _context.appointments.Find(id);
        if (booking == null)
        {
            return NotFound();
        }
        return View(booking);
    }


    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateBooking(Appointment booking)
    {
        if (ModelState.IsValid)
        {
            _context.appointments.Update(booking);
            _context.SaveChanges();
            return RedirectToAction("Main");
        }
        return View(booking);
    }
}

}