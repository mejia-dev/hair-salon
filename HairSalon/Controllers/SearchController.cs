using HairSalon.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace HairSalon.Controllers
{
  public class SearchController : Controller
  {
    private readonly HairSalonContext _db;

    public SearchController(HairSalonContext db)
    {
      _db = db;
    }

    private async Task<List<Client>> DoClientSearch(string query)
    {
      IQueryable<Client> results = _db.Set<Client>().Include(client => client.Stylist);

      if (query != null)
      {
        return await results?.Where(
          client => client.ClientName.Contains(query) || 
          client.ClientDetails.Contains(query) || 
          client.Stylist.StylistName.Contains(query)
          ).ToListAsync();
      }
      else
      {
        return await results.ToListAsync();
      }
    }

    private async Task<List<Stylist>> DoStylistSearch(string query)
    {
      IQueryable<Stylist> results = _db.Set<Stylist>();

      if (query != null)
      {
        return await results?.Where(
          stylist => stylist.StylistName.Contains(query) || 
          stylist.StylistDetails.Contains(query)
          ).ToListAsync();
      }
      else
      {
        return await results.ToListAsync();
      }
    }

    public async Task<IActionResult> Index(string query)
    {
      ViewBag.PageTitle = $"Search results for {query}";
      List<Client> clientResults = await DoClientSearch(query);
      if (clientResults.Count == 0)
      {
        List<Stylist> stylistResults = await DoStylistSearch(query);
        ViewBag.SearchType = "stylists";
        return View(stylistResults);
      }
      else
      {
        ViewBag.SearchType = "clients";
        return View(clientResults);
      } 
    }
  }
}