using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cKitchen.Entities.HuyND.Models;

namespace cKitchen.Services.HuyND
{
    public interface IInventoryHuyNDService
    {
        
        //query methods here
        Task<List<InventoryHuyNd>> GetAllAsync();
        Task<InventoryHuyNd> GetByIdAsync(int id);
        Task<List<InventoryHuyNd>> SearchAsync(string batchNum, int quantity, string localName);

        //Mutation methods
        Task<int> CreateAsync(InventoryHuyNd inventoryHuyNd);
        Task<int> UpdateAsync(InventoryHuyNd inventoryHuyNd);
        Task<bool> DeleteAsync(int id);
    }
}
