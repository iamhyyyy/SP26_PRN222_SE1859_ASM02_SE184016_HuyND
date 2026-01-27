using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cKitchen.Entities.HuyND.Models;
using cKitchen.Repositories.HuyND.Basis;
using cKitchen.Repositories.HuyND.DBContext;
using Microsoft.EntityFrameworkCore;

namespace cKitchen.Repositories.HuyND
{
    public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
    {
        public SystemUserAccountRepository() { }

        public SystemUserAccountRepository(CentralKitchenFranchiseDBContext context) => _context = context;

        public async Task<SystemUserAccount> GetUserAccountAsync(string username, string password)
        {
            return await _context.SystemUserAccounts
                .FirstOrDefaultAsync(u => u.Email == username && u.Password == password && u.IsActive == true);

            //return await _context.SystemUserAccounts
            //    .FirstOrDefaultAsync(u => u.Phone == username && u.Password == password && u.IsActive == true);

            //return await _context.SystemUserAccounts
            //    .FirstOrDefaultAsync(u => u.UserName == username && u.Password == password && u.IsActive == true);

            //return await _context.SystemUserAccounts
            //    .FirstOrDefaultAsync(u => u.EmployeeCode == username && u.Password == password && u.IsActive == true);
        }
    }
}
