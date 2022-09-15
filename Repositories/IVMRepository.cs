using VendingMachineAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachineAPI.Repositories
{
    public interface IVMRepository
    {
        Task<IEnumerable<Item>> Get();
        Task<Item> Get(int id);
        Task<Item> Create(Item item);
        Task Update(Item item);
        Task Delete(int id);
    }
}
