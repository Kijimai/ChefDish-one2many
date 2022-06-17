using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ChefsNDishes.Models;

public class DishesController : Controller
{
  private CDContext _context;

  public DishesController(CDContext context)
  {
    _context = context;
  }

  [HttpGet("dishes")]
  public IActionResult ShowDishes()
  {
    List<Dish> AllDishesWithUser = _context.Dishes.Include(dish => dish.Author).ToList();
    return View("ShowDishes", AllDishesWithUser);
  }

  [HttpGet("/add_dish")]
  public IActionResult New()
  {
    List<Chef> AllChefs = _context.Chefs.ToList();
    ViewBag.AllChefs = AllChefs;
    return View("AddDish");
  }

  [HttpPost("/dishes/create")]
  public IActionResult Create(Dish newDish)
  {
    if (ModelState.IsValid)
    {
      _context.Dishes.Add(newDish);
      _context.SaveChanges();
      return RedirectToAction("ShowDishes");
    }
    return New();
  }

}