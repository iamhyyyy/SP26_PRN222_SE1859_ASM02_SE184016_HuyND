using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Repositories.HuyND;

namespace cKitchen.Services.HuyND
{
    public class InventoryLocationHuyNDService
    {
        private readonly InventoryLocationHuyNDRepository _repository;

        public InventoryLocationHuyNDService() => _repository = new InventoryLocationHuyNDRepository();

        public async Task<List<InventoryLocationHuyNd>> GetAllAsync() => await _repository.GetAllAsync();

    }
}
