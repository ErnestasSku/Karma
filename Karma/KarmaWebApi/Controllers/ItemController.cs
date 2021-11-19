using Backend.Utils;
using DataBase.Models;
using DataBase.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace KarmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {

        public static ItemService ItemService = ItemService.Instance;


        [HttpGet]
        public async Task<IEnumerable<Item>> Get()
        {
            try
            {
                return await ItemService.GetAllItems();
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
                return await ItemService.GetSpecificItem(id);
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
                int res = ItemService.InsertItem(value);
                Email<Item> email = new Email<Item>();
                email.EmailActionCompleted += (Item item) =>
                {
                    SmtpClient client = new SmtpClient();
                    MailAddress from = new MailAddress("Karma@gmail.com");
                    MailAddress to = new MailAddress(item.Poster.Email);
                    MailMessage message = new MailMessage(from, to);
                    message.Body = "Test message";
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Subject = "Item posted";
                    message.SubjectEncoding = System.Text.Encoding.UTF8;
                    client.SendAsync(message, null);
                };

                if (res == 0)
                {
                    email.OnEmailActionCompleted(value);
                    return Ok();
                } else
                {
                    return BadRequest();
                }
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
                _ = await ItemService.UpdateItem(value);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Error("Error during Item API Put " + ex.Message);
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                Item item = await ItemService.GetSpecificItem(id);
                ItemService.DeleteItem(item);
                
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
