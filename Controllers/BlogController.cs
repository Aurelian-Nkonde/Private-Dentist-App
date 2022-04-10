using System;
using Microsoft.AspNetCore.Mvc;
using DentistApp.Models;
using DentistApp.Data;
using System.Collections.Generic;


namespace DentistApp.Controllers
{
    public class BlogController : Controller
{
    private readonly ApplicationDbContext _db;

    public BlogController(ApplicationDbContext db)
    {
        _db = db;
    }

    public IActionResult BlogDetail(int? id)
    {
        if (id == null && id == null)
        {
            return NotFound();
        }
        var blog = _db.blogs.Find(id);
        if (blog == null)
        {
            return NotFound();
        }
        return View(blog);
    }


    public IActionResult BlogList()
    {
        IEnumerable<Blog> blogs = _db.blogs; 
        return View(blogs);
    }


}

}