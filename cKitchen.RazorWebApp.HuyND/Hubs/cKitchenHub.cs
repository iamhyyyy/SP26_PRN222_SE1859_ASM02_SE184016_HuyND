using cKitchen.Services.HuyND;
using Microsoft.AspNetCore.SignalR;

namespace cKitchen.RazorWebApp.HuyND.Hubs
{
    public class cKitchenHub : Hub
    {
        private readonly IInventoryHuyNDService _inventoryHuyNDService;
        private readonly InventoryLocationHuyNDService _inventoryLocationHuyNDService;

        public cKitchenHub(IInventoryHuyNDService inventoryHuyNDService,
            InventoryLocationHuyNDService inventoryLocationHuyNDService)
        {
            _inventoryHuyNDService = inventoryHuyNDService;
            _inventoryLocationHuyNDService = inventoryLocationHuyNDService;
        }

        public async Task HubDelete_InventoryHuyND(int inventoryHuyNDId) 
        {
            

            await Clients.All.SendAsync("ReceiverDelete_InventoryHuyND", inventoryHuyNDId);

            await _inventoryHuyNDService.DeleteAsync(inventoryHuyNDId);
        }
    }
}
