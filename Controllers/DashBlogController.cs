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
    private readonly ApplicationDbContext _database;

    public DashBlogController(ApplicationDbContext database)
    {
        _database = database;
    }


    [Authorize]
    public IActionResult Dashboard()
    {
        IEnumerable<Blog> AllblogsPosts = _database.blogs;
        return View(AllblogsPosts);
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
            _database.blogs.Add(data);
            _database.SaveChanges();
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
        var blogPost = _database.blogs.Find(id);
        if (blogPost == null)
        {
            return NotFound();
        }
        return View(blogPost);
    }

    [Authorize]
    [HttpPost]
    public IActionResult DeleteBlogs(int? id)
    {
        if (id == 0 && id == null)
        {
            return NotFound();
        }
        var blogToDelete = _database.blogs.Find(id);
        if (blogToDelete != null)
        {
            _database.blogs.Remove(blogToDelete);
            _database.SaveChanges();
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
        var blogPost = _database.blogs.Find(id);
        if (blogPost == null)
        {
            return NotFound();
        }
        return View(blogPost);
    }

    [Authorize]
    [HttpGet]
    public IActionResult UpdateBlog(int? id)
    {
        if (id == null && id == 0)
        {
            return NotFound();
        }
        var FindingAblog = _database.blogs.Find(id);
        Blog blogPost;
        if (FindingAblog != null)
        {
            blogPost = FindingAblog;
            if (blogPost == null)
            {
                return NotFound();
            }
            return View(blogPost);
        }

        return View(FindingAblog);
    }


    [Authorize]
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult UpdateBlog(Blog data)
    {
        if (ModelState.IsValid)
        {
            _database.blogs.Update(data);
            _database.SaveChanges();
            return RedirectToAction("Dashboard");
        }
        return View(data);
    }
}

}