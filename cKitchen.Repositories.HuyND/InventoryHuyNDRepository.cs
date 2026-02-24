using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Repositories.HuyND.Basis;
using cKitchen.Repositories.HuyND.DBContext;
using Microsoft.EntityFrameworkCore;

namespace cKitchen.Repositories.HuyND
{
    public class InventoryHuyNDRepository : GenericRepository<InventoryHuyNd>
    {
        public InventoryHuyNDRepository() { }

        public InventoryHuyNDRepository(CentralKitchenFranchiseDBContext context) => _context = context;


        public async Task<List<InventoryHuyNd>> GetAllAsync()
        {
            var items = await _context.InventoryHuyNds
                .Include(i => i.CentralKitchenKhaiVpm)
                .Include(i => i.InventoryLocationHuyNd)
                .ToListAsync();
            return items ?? new List<InventoryHuyNd>();
        }

        public async Task<InventoryHuyNd> GetByIdAsync(int id)
        {
            // FindAsync does not load navigation properties; use Include for Details page
            var item = await _context.InventoryHuyNds
                .Include(i => i.CentralKitchenKhaiVpm)
                .Include(i => i.InventoryLocationHuyNd)
                .FirstOrDefaultAsync(i => i.InventoryHuyNdid == id);
            return item ?? new InventoryHuyNd();
        }



        public async Task<List<InventoryHuyNd>> SearchAsync(string batchNum, int quantity, string localName)
        {
            var items = await _context.InventoryHuyNds
                .Include(i => i.CentralKitchenKhaiVpm)
                .Include(i => i.InventoryLocationHuyNd)
                .Where(i =>
                    ((i.BatchNumber != null && i.BatchNumber.Contains(batchNum)) || string.IsNullOrEmpty(batchNum)) &&
                    (i.Quantity == quantity || quantity == 0) &&
                    (((i.InventoryLocationHuyNd != null) && (i.InventoryLocationHuyNd.LocationName != null) && i.InventoryLocationHuyNd.LocationName.Contains(localName))
                        || string.IsNullOrEmpty(localName))
                ).ToListAsync();

            return items ?? new List<InventoryHuyNd>();
        }
    }
}
