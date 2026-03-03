using cKitchen.Entities.HuyND.Models;
using cKitchen.Services.HuyND;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;

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

        public async Task HubCreate_InventoryHuyND(string inventoryHuyNDJsonString)
        {
            var item = JsonConvert.DeserializeObject<InventoryHuyNd>(inventoryHuyNDJsonString);

            await Clients.All.SendAsync("ReceiverCreate_InventoryHuyND", item);

            await _inventoryHuyNDService.CreateAsync(item);
        }

        public async Task HubUpdate_InventoryHuyND(string inventoryHuyNDJsonString)
        {
            var item = JsonConvert.DeserializeObject<InventoryHuyNd>(inventoryHuyNDJsonString);

            await Clients.All.SendAsync("ReceiverUpdate_InventoryHuyND", item);

            await _inventoryHuyNDService.UpdateAsync(item);

        }
    }
}
