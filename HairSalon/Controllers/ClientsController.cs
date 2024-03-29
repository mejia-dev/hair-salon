using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace HairSalon.Controllers
{
  public class ClientsController : Controller
  {
    private readonly HairSalonContext _db;

    public ClientsController(HairSalonContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      ViewBag.PageTitle = "Clients";
      return View(_db.Clients.Include(client => client.Stylist).ToList());
    }

    public ActionResult Create(string error)
    {
      ViewBag.PageTitle = "Add a Client";
      ViewBag.ErrorMessage = error;
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "StylistName");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Client client)
    {
      if (client.StylistId == 0)
      {
        return RedirectToAction("Create", new { error = "noStylists" });
      }
      _db.Clients.Add(client);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Client selectedClient = _db.Clients.Include(client => client.Stylist).FirstOrDefault(client => client.ClientId == id);
      ViewBag.PageTitle = $"Client Details - {selectedClient.ClientName}";
      return View(selectedClient);
    }

    public ActionResult Edit(int id)
    {
      Client selected = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      ViewBag.PageTitle = $"Edit Client - {selected.ClientName}";
      ViewBag.StylistId = new SelectList(_db.Stylists, "StylistId", "StylistName");
      return View(selected);
    }

    [HttpPost]
    public ActionResult Edit(Client client)
    {
      _db.Clients.Update(client);
      _db.SaveChanges();
      return RedirectToAction("Details", new { id = client.ClientId });
    }

    public ActionResult Delete(int id)
    {
      Client selectedClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      ViewBag.PageTitle = $"Delete Client - {selectedClient.ClientName}";
      return View(selectedClient);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Client selectedClient = _db.Clients.FirstOrDefault(client => client.ClientId == id);
      _db.Clients.Remove(selectedClient);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}