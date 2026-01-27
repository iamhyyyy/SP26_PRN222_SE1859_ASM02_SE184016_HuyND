using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Repositories.HuyND.DBContext;

namespace cKitchen.RazorWebApp.HuyND.Pages.InventoryHuyNds
{
    public class DeleteModel : PageModel
    {
        private readonly cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext _context;

        public DeleteModel(cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext context)
        {
            _context = context;
        }

        [BindProperty]
        public InventoryHuyNd InventoryHuyNd { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryhuynd = await _context.InventoryHuyNds.FirstOrDefaultAsync(m => m.InventoryHuyNdid == id);

            if (inventoryhuynd == null)
            {
                return NotFound();
            }
            else
            {
                InventoryHuyNd = inventoryhuynd;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventoryhuynd = await _context.InventoryHuyNds.FindAsync(id);
            if (inventoryhuynd != null)
            {
                InventoryHuyNd = inventoryhuynd;
                _context.InventoryHuyNds.Remove(InventoryHuyNd);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
