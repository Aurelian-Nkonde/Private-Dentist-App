using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DentistApp.Models;
using DentistApp.Data;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;



namespace DentistApp.Controllers
{
    public class DashBlogController : Controller
{
    private readonly ApplicationDbContext _db;

    public DashBlogController(ApplicationDbContext db)
    {
        _db = db;
    }


    [Authorize]
    public IActionResult Dashboard()
    {
        IEnumerable<Blog> blogs = _db.blogs;
        return View(blogs);
    }


    [Authorize]

    public IActionResult CreateBlog()
    {
        return View();
    }


    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult CreateBlog(Blog data)
    {
        if (ModelState.IsValid)
        {
            _db.blogs.Add(data);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        return View(data);
    }


    [Authorize]
    public IActionResult DeleteBlog(int? id)
    {
        if(id == null && id == 0)
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

    [Authorize]
    [HttpPost]
    public IActionResult DeleteBlogs(int? id)
    {
        if (id == 0 && id == null)
        {
            return NotFound();
        }
        var blogToDelete = _db.blogs.Find(id);
        if (blogToDelete != null)
        {
            _db.blogs.Remove(blogToDelete);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        return View(blogToDelete);
    }


    [Authorize]
    public IActionResult DetailBlog(int? id)
    {
        if (id == null && id == 0)
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

    [Authorize]
    [HttpGet]
    public IActionResult UpdateBlog(int? id)
    {
        if (id == null && id == 0)
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


    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateBlog(Blog data)
    {
        if (ModelState.IsValid)
        {
            _db.blogs.Update(data);
            _db.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        return View(data);
    }
}

}