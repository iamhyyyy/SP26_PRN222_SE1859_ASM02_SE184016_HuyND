using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Services.HuyND;
using Microsoft.AspNetCore.Authorization;

namespace cKitchen.RazorWebApp.HuyND.Pages.InventoryHuyNds
{
    [Authorize(Roles = "1,2")]
    //[Authorize]
    public class IndexModel : PageModel
    {
        //private readonly cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext _context;
        private readonly IInventoryHuyNDService _inventoryHuyNDService;

        //public IndexModel(cKitchen.Repositories.HuyND.DBContext.CentralKitchenFranchiseDBContext context)
        //{
        //    _context = context;
        //}
        public IndexModel(IInventoryHuyNDService inventoryHuyNDService) => _inventoryHuyNDService = inventoryHuyNDService;


        // Always initialize to avoid NullReference in Razor (@foreach)
        public IList<InventoryHuyNd> InventoryHuyNd { get; set; } = new List<InventoryHuyNd>();

        //public async Task OnGetAsync()
        //{
        //    //InventoryHuyNd = await _context.InventoryHuyNds
        //    //    .Include(i => i.CentralKitchenKhaiVpm)
        //    //    .Include(i => i.InventoryLocationHuyNd).ToListAsync();
        //    InventoryHuyNd = await _inventoryHuyNDService.GetAllAsync();
        //}

        public async Task OnGetAsync()
        {
            //InventoryHuyNd = await _context.InventoryHuyNds
            //    .Include(i => i.CentralKitchenKhaiVpm)
            //    .Include(i => i.InventoryLocationHuyNd).ToListAsync();
            var batchNum = (string?)Request.Query["batchNum"];
            var localName = (string?)Request.Query["localName"];

            var quantityRaw = (string?)Request.Query["quantity"];
            var quantity = int.TryParse(quantityRaw, out var q) ? q : 0;

            InventoryHuyNd = await _inventoryHuyNDService.SearchAsync(
                batchNum: (batchNum ?? string.Empty).Trim(),
                quantity: quantity,
                localName: (localName ?? string.Empty).Trim()
            ) ?? new List<InventoryHuyNd>();

        }
    }
}