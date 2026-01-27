using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Repositories.HuyND.DBContext;

namespace cKitchen.RazorWebApp.HuyND.Pages.InventoryHuyNds
{
    public class CreateModel : PageModel
    {
        private readonly cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext _context;

        public CreateModel(cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CentralKitchenKhaiVpmid"] = new SelectList(_context.CentralKitchenKhaiVpms, "CentralKitchenKhaiVpmid", "CentralKitchenKhaiVpmid");
        ViewData["InventoryLocationHuyNdid"] = new SelectList(_context.InventoryLocationHuyNds, "InventoryLocationHuyNdid", "InventoryLocationHuyNdid");
            return Page();
        }

        [BindProperty]
        public InventoryHuyNd InventoryHuyNd { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.InventoryHuyNds.Add(InventoryHuyNd);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
