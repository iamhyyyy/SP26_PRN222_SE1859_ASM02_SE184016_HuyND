using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Repositories.HuyND.DBContext;

namespace cKitchen.RazorWebApp.HuyND.Pages.InventoryHuyNds
{
    public class EditModel : PageModel
    {
        private readonly cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext _context;

        public EditModel(cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext context)
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

            var inventoryhuynd =  await _context.InventoryHuyNds.FirstOrDefaultAsync(m => m.InventoryHuyNdid == id);
            if (inventoryhuynd == null)
            {
                return NotFound();
            }
            InventoryHuyNd = inventoryhuynd;
           ViewData["CentralKitchenKhaiVpmid"] = new SelectList(_context.CentralKitchenKhaiVpms, "CentralKitchenKhaiVpmid", "CentralKitchenKhaiVpmid");
           ViewData["InventoryLocationHuyNdid"] = new SelectList(_context.InventoryLocationHuyNds, "InventoryLocationHuyNdid", "InventoryLocationHuyNdid");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(InventoryHuyNd).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventoryHuyNdExists(InventoryHuyNd.InventoryHuyNdid))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool InventoryHuyNdExists(int id)
        {
            return _context.InventoryHuyNds.Any(e => e.InventoryHuyNdid == id);
        }
    }
}
