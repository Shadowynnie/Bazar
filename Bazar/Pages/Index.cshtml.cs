using System.Collections.Generic;
using System.Linq;
using Bazar.Data;
using Bazar.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Bazar.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _context;

        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public List<Item> Items { get; set; }

        public void OnGet()
        {
            Items = _context.Items.ToList();
        }

        public IActionResult OnPostBuy(int id)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == id);
            if (item == null)
            {
                return NotFound();
            }

            if (item.Sold)
            {
                TempData["Message"] = "This item is already sold.";
            }
            else
            {
                // Zde provedete akci pro označení položky jako prodané
                item.Sold = true;
                _context.SaveChanges();
                TempData["Message"] = "Item purchased successfully.";
            }

            return RedirectToPage("/Index");
        }
    }
}
