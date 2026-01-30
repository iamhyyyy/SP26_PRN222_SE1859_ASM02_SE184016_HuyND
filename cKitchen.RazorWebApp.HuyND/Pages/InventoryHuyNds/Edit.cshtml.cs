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
using cKitchen.Services.HuyND;

namespace cKitchen.RazorWebApp.HuyND.Pages.InventoryHuyNds
{
    public class EditModel : PageModel
    {
        //private readonly cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext _context;
        private readonly IInventoryHuyNDService _inventoryHuyNDService;
        private readonly InventoryLocationHuyNDService _inventoryLocationHuyNdService;

        //public EditModel(cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext context)
        //{
        //    _context = context;
        //}
        public EditModel(IInventoryHuyNDService inventoryHuyNDService, InventoryLocationHuyNDService inventoryLocationHuyNdService)
        {
            _inventoryHuyNDService = inventoryHuyNDService;
            _inventoryLocationHuyNdService = inventoryLocationHuyNdService;
        }

        [BindProperty]
        public InventoryHuyNd InventoryHuyNd { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var inventoryhuynd = await _context.InventoryHuyNds.FirstOrDefaultAsync(m => m.InventoryHuyNdid == id); 
            var inventoryhuynd = await _inventoryHuyNDService.GetByIdAsync(id.Value);
            if (inventoryhuynd == null)
            {
                return NotFound();
            }
            InventoryHuyNd = inventoryhuynd;
            var inventoryLocationHuyNds = await _inventoryLocationHuyNdService.GetAllAsync();
            //ViewData["CentralKitchenKhaiVpmid"] = new SelectList(_context.CentralKitchenKhaiVpms, "CentralKitchenKhaiVpmid", "CentralKitchenKhaiVpmid");
            ViewData["InventoryLocationHuyNd"] = inventoryhuynd.InventoryLocationHuyNd;
            ViewData["InventoryLocationHuyNdid"] = new SelectList(inventoryLocationHuyNds, "InventoryLocationHuyNdid", "InventoryLocationHuyNdid", inventoryhuynd.InventoryLocationHuyNd.InventoryLocationHuyNdid);
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

            //_context.Attach(InventoryHuyNd).State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!InventoryHuyNdExists(InventoryHuyNd.InventoryHuyNdid))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            var result = await _inventoryHuyNDService.UpdateAsync(InventoryHuyNd);
            if(result > 0)
            {
                return RedirectToPage("./Index");
            }
            return Page();

        }

        //private bool InventoryHuyNdExists(int id)
        //{
        //    return _context.InventoryHuyNds.Any(e => e.InventoryHuyNdid == id);
        //}
    }
}
