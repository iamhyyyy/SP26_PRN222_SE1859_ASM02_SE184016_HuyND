using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Repositories.HuyND;

namespace cKitchen.Services.HuyND
{
    public class InventoryHuyNDService : IInventoryHuyNDService
    {
        private readonly InventoryHuyNDRepository  _inventoryHuyNDRepository;
        //private readonly InventoryLocationHuyNDService _inventoryLocationHuyNDRervicerepository;

        public InventoryHuyNDService() => _inventoryHuyNDRepository ??= new InventoryHuyNDRepository();
        //public InventoryHuyNDService(InventoryHuyNDService inventoryHuyNDService)
        //{
        //    _inventoryHuyNDRepository = inventoryHuyNDService;
        //    //_inventoryLocationHuyNDRervicerepository = new InventoryLocationHuyNDService();
        //}
        
        public async Task<int> CreateAsync(InventoryHuyNd inventoryHuyNd)
        {
            try
            {
                return await _inventoryHuyNDRepository.CreateAsync(inventoryHuyNd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var item = await _inventoryHuyNDRepository.GetByIdAsync(id);
                if (item != null)
                {
                    return await _inventoryHuyNDRepository.RemoveAsync(item);
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
            //throw new NotImplementedException();
        }

        public async Task<List<InventoryHuyNd>> GetAllAsync()
        {
            try
            {
                return await _inventoryHuyNDRepository.GetAllAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<InventoryHuyNd> GetByIdAsync(int id)
        {
            try
            {
                return await _inventoryHuyNDRepository.GetByIdAsync(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //throw new NotImplementedException();
        }

        public async Task<List<InventoryHuyNd>> SearchAsync(string batchNum, int quantity, string localName)
        {
            try
            {
                return await _inventoryHuyNDRepository.SearchAsync(batchNum, quantity, localName);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
                //throw;
            }
            //throw new NotImplementedException();
        }

        public async Task<int> UpdateAsync(InventoryHuyNd inventoryHuyNd)
        {
            try
            {
                return await _inventoryHuyNDRepository.UpdateAsync(inventoryHuyNd);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //throw new NotImplementedException();
        }


    }

    
}
