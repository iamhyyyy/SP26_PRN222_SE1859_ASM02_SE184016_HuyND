using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Repositories.HuyND.DBContext;
using cKitchen.Services.HuyND;

namespace cKitchen.RazorWebApp.HuyND.Pages.InventoryHuyNds
{
    public class DetailsModel : PageModel
    {
        //private readonly cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext _context;
        private readonly IInventoryHuyNDService _inventoryHuyNDService;

        //public DetailsModel(cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext context)
        //{
        //    _context = context;
        //}

        public DetailsModel(IInventoryHuyNDService inventoryHuyNDService) => _inventoryHuyNDService = inventoryHuyNDService;
        

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
            else
            {
                InventoryHuyNd = inventoryhuynd;
            }
            return Page();
        }
    }
}
