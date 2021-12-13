using Backend.Utils;
using Database.Models;
using Database.Services;
using DataBase.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KarmaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private static ConversationService _conversationService;

        public ConversationController(IDatabaseContext databaseContext)
        {
            _conversationService = new ConversationService(databaseContext);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Conversation>>> GetAll()
        {
            try
            {
                return await _conversationService.GetAllConversations();
            }
            catch (Exception ex)
            {
                Logger.Info("Error during Conversation API GET " + ex.Message);
                return null;
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Conversation>> GetUserConversations(int id)
        {
            try
            {
                return await _conversationService.GetUserConversations(id);
            }
            catch (Exception ex)
            {
                Logger.Info("Error during Conversation API GET " + ex.Message);
                return null;
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostNewConversation([FromBody]Conversation conversation)
        {
            try
            {
                int res = await _conversationService.CreateConversation(conversation);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Error("Error during Conversation API POST " + ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                Conversation conversation = await _conversationService.GetSpecificConversation(id);
                await _conversationService.DeleteConversation(conversation);
                return Ok();
            }
                        catch (Exception ex)
            {
                Logger.Error("Error during Conversation API DELETE " + ex.Message);
                return NotFound();

            }

        }
    }
}
