using VendingMachineAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachineAPI.Repositories
{
    public class VMRepository : IVMRepository
    {
        private readonly ItemContext _context;

        public VMRepository(ItemContext context)
        {
            _context = context;
        }

        public async Task<Item> Create(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();

            return item;
        }

        public async Task Delete(int id)
        {
            var itemToDelete = await _context.Items.FindAsync(id);
            _context.Items.Remove(itemToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Item>> Get()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> Get(int id)
        {
            return await _context.Items.FindAsync(id);
        }

        public async Task Update(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
