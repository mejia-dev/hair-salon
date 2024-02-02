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

    private async Task<List<Client>> DoSearch(string query)
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

    public async Task<IActionResult> Index(string query)
    {
      List<Client> resultList = await DoSearch(query);
      ViewBag.PageTitle = "Search Results";
      return View(resultList);
    }
  }
}