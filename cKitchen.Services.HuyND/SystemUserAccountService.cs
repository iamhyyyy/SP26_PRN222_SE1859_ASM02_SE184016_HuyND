using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Repositories.HuyND;

namespace cKitchen.Services.HuyND
{
    public class SystemUserAccountService
    {
        private readonly SystemUserAccountRepository _repository;
        public SystemUserAccountService() => _repository = new SystemUserAccountRepository();

        public async Task<SystemUserAccount> GetUserAccountAsync(string username, string password)
        {
            try
            {
                return await _repository.GetUserAccountAsync(username, password);
            }
            catch(Exception ex) 
            {
                throw new Exception(ex.Message);
            }
            
        }

    }
}
