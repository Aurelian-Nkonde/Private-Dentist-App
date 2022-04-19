using System;
using Microsoft.AspNetCore.Mvc;
using DentistApp.Models;
using DentistApp.Data;
using System.Collections.Generic;


namespace DentistApp.Controllers
{
    public class BlogController : Controller
{
    private readonly ApplicationDbContext _database;

    public BlogController(ApplicationDbContext db)
    {
        _database = db;
    }

    public IActionResult BlogDetail(int? id)
    {
        if (id == null && id == null)
        {
            return NotFound();
        }
        var SingleblogDetail = _database.blogs.Find(id);
        if (SingleblogDetail == null)
        {
            return NotFound();
        }
        return View(SingleblogDetail);
    }


    public IActionResult BlogList()
    {
        IEnumerable<Blog> Totalblogs = _database.blogs; 
        return View(Totalblogs);
    }


}

}