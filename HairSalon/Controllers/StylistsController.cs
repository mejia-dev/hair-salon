using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class StylistsController : Controller
  {
    private readonly HairSalonContext _db;

    public StylistsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "Stylists";
      return View(_db.Stylists.ToList());
    }

    public ActionResult Create()
    {
      ViewBag.PageTitle = "Add a Stylist";
      return View();
    }

    [HttpPost]
    public ActionResult Create(Stylist stylist)
    {
      _db.Stylists.Add(stylist);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Stylist selected = _db.Stylists.FirstOrDefault(stylist => stylist.StylistId == id);
      ViewBag.PageTitle = $"Stylist Details - {selected.StylistName}";
      return View(selected);
    }
  }
}