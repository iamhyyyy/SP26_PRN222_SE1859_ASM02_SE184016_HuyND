using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Repositories.HuyND.DBContext;
using cKitchen.Services.HuyND;

namespace cKitchen.RazorWebApp.HuyND.Pages.InventoryHuyNds
{
    public class CreateModel : PageModel
    {
        //private readonly cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext _context;
        private readonly IInventoryHuyNDService _inventoryHuyNDService;
        private readonly InventoryLocationHuyNDService _inventoryLocationHuyNdService;

        //public CreateModel(cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext context)
        //{
        //    _context = context;
        //}
        public CreateModel(IInventoryHuyNDService inventoryHuyNDService, InventoryLocationHuyNDService inventoryLocationHuyNdService)
        {
            _inventoryHuyNDService = inventoryHuyNDService;
            _inventoryLocationHuyNdService = inventoryLocationHuyNdService;
        }

        public async Task<IActionResult> OnGet()
        {
            var InventoryLocationHuyNds = await _inventoryLocationHuyNdService.GetAllAsync();
            //ViewData["CentralKitchenKhaiVpmid"] = new SelectList(_context.CentralKitchenKhaiVpms, "CentralKitchenKhaiVpmid", "CentralKitchenKhaiVpmid");
            ViewData["InventoryLocationHuyNdid"] = new SelectList(InventoryLocationHuyNds, "InventoryLocationHuyNdid", "LocationName");

            //Set default value
            InventoryHuyNd = new InventoryHuyNd()
            {

                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsActive = true,
                CentralKitchenKhaiVpmid = 1 // Default to 1 for now

            };

            //return Page(newInventoryHuyNd);
            return Page();
        }

        [BindProperty]
        public InventoryHuyNd InventoryHuyNd { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var inventoryLocationHuyNds = await _inventoryLocationHuyNdService.GetAllAsync();
                ViewData["InventoryLocationHuyNdid"] = new SelectList(
                    inventoryLocationHuyNds,
                    "InventoryLocationHuyNdid",
                    "LocationName",
                    InventoryHuyNd?.InventoryLocationHuyNdid
                );
                return Page();
            }
            var result = await _inventoryHuyNDService.CreateAsync(InventoryHuyNd);

            if (result > 0) return RedirectToPage("./Index");
            else
            {
                var inventoryLocationHuyNds = await _inventoryLocationHuyNdService.GetAllAsync();
                ViewData["InventoryLocationHuyNdid"] = new SelectList(
                    inventoryLocationHuyNds,
                    "InventoryLocationHuyNdid",
                    "LocationName",
                    InventoryHuyNd?.InventoryLocationHuyNdid
                );
                return Page();
            }

            //_context.InventoryHuyNds.Add(InventoryHuyNd);
            //await _context.SaveChangesAsync();
        }
    }
}
