using VendingMachineAPI.Models;
using VendingMachineAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendingMachineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendingMachineController : ControllerBase
    {
        private readonly IVMRepository _VMRepository;

        public VendingMachineController(IVMRepository VMRepository)
        {
            _VMRepository = VMRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> GetItems()
        {
            return await _VMRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItems(int id)
        {
            return await _VMRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Item>>PostItems([FromBody] Item item)
        {
            var newItem = await _VMRepository.Create(item);
            return CreatedAtAction(nameof(GetItems), new { id = newItem.Id }, newItem);
        }

        [HttpPut]
        public async Task<ActionResult> PutItems(int id, [FromBody] Item item)
        {
            if(id != item.Id)
            {
                return BadRequest();
            }

            await _VMRepository.Update(item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete (int id)
        {
            var itemToDelete = await _VMRepository.Get(id);
            if (itemToDelete == null)
                return NotFound();

            await _VMRepository.Delete(itemToDelete.Id);
            return NoContent();
        }
    }
}
