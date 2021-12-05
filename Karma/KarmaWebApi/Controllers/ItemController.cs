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
        private static ItemService _itemService;

        public ItemController(IDatabaseContext databaseContext)
        {
            _itemService = new ItemService(databaseContext);
        }

        [HttpGet]
        public async Task<IEnumerable<Item>> GetAll()
        {
            try
            {
                return await _itemService.GetAllItems();
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
        public async Task<ActionResult<Item>> GetById(int id)
        {
            try
            {
                return await _itemService.GetSpecificItem(id);
            }
            catch (Exception ex)
            {
                Logger.Error("Error during Item API GET " + ex.Message);
                return NotFound();
            }

        }

        // POST api/Item
        [HttpPost]
        public async Task<IActionResult> PostNewItem([FromBody] Item value)
        {
            try
            {
                int res = await _itemService.InsertItem(value);
                Email<Item> email = new Email<Item>();
                email.EmailActionCompleted += (Item item) =>
                {
                    SmtpClient client = new SmtpClient();
                    MailAddress from = new MailAddress("KarmaTeam@noreply.com");
                    MailAddress to = new MailAddress("ernis2580@gmail.com");
                    // MailAddress to = new MailAddress(item.Poster.Email);
                    MailMessage message = new MailMessage(from, to);
                    message.Body = "Test message";
                    message.BodyEncoding = System.Text.Encoding.UTF8;
                    message.Subject = "Test message";
                    message.SubjectEncoding = System.Text.Encoding.UTF8;

                    //client.Host = "smtp.gmail.com";
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.UseDefaultCredentials = false;
                    client.SendAsync(message, null);
                };

                return Ok();

            }
            catch (Exception ex)
            {
                Logger.Error("Error during Item API POST " + ex.Message);
                return BadRequest();
            }


        }

        // PUT api/Item
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Item value)
        {
            try
            {
                await _itemService.UpdateItem(id, value);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Error("Error during Item API Put " + ex.Message);
                return NoContent();
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                Item item = await _itemService.GetSpecificItem(id);
                await _itemService.DeleteItem(item);

                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Error("Error during Item API DELETE " + ex.Message);
                return NotFound();

            }
        }

        [HttpGet("?item_page={pageNumber}&item_view={itemNumber}")]
        public async Task<IEnumerable<Item>> GetPageItems(int pageNumber, int itemNumber)
        {
            return await _itemService.GetPageItems(pageNumber, itemNumber);
        }
    }
    
}
