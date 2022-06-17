using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;

public class ChefsController : Controller
{
  private CDContext _context;

  public ChefsController(CDContext context)
  {
    _context = context;
  }

  [HttpGet("")]
  public IActionResult ShowChefs()
  {
    List<Chef> AllChefsWithDishes = _context.Chefs.Include(chef => chef.Dishes).ToList();
    return View("ShowChefs", AllChefsWithDishes);
  }

  [HttpGet("/add_chef")]
  public IActionResult New()
  {
    return View("AddChef");
  }

  [HttpPost("/chefs/create")]
  public IActionResult Create(Chef newChef)
  {
    if (ModelState.IsValid)
    {
      _context.Chefs.Add(newChef);
      _context.SaveChanges();
      return RedirectToAction("ShowChefs");
    }
    return New();
  }
}