using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Repositories.HuyND.Basis;
using cKitchen.Repositories.HuyND.DBContext;

namespace cKitchen.Repositories.HuyND
{
    public class InventoryLocationHuyNDRepository : GenericRepository<InventoryLocationHuyNd>
    {
        public InventoryLocationHuyNDRepository() { }

        public InventoryLocationHuyNDRepository(CentralKitchenFranchiseDBContext context) => _context = context;

    }
}
