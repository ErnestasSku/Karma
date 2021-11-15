using Backend.Utils;
using DataBase.Models;
using DataBase.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KarmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        public static ItemService itemService = new ItemService();

        public static List<Item> Items { get; } = new List<Item>();

        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            try
            {
                return await itemService.GetAllItems();
            }
            catch (Exception ex)
            {
                Logger.Info("Error during Item API GET " + ex.Message);
                return null;
            }
            
            //return Items;
        }

        // GET api/Items/0
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            try
            { 
                return await itemService.GetSpecificItem(id);
            }
            catch (Exception ex)
            {
                Logger.Error("Error during Item API GET " + ex.Message);
                return NotFound();
            }
            
            
            //return Items.FirstOrDefault(c => c.ItemId == id);
        }

        // POST api/Item
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Item value)
        {
            try
            {
                itemService.InsertItem(value);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Error("Error during Item API POST " + ex.Message);
                return Forbid();
            }
            
            //Items.Add(value);
        }

        // PUT api/Item
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Item value)
        {
            try
            {
                value.ItemId = id;
                _ = await itemService.UpdateItem(value);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Error("Error during Item API Put " + ex.Message);
                return NoContent();
            }
            
            /*var item = Items.FirstOrDefault(c => c.ItemId == id);
            if (item == null)
                return;
            item = value;*/
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Item item = await itemService.GetSpecificItem(id);
                itemService.DeleteItem(item);
                
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Error("Error during Item API DELETE " + ex.Message);
                return NotFound();
            }

            /*var item = Items.FirstOrDefault(c => c.ItemId == id);
            if (item == null)
                return;

            Items.Remove(item);*/
        }

    }
}
