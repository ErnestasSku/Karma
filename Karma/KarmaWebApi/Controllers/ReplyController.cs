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
    public class ReplyController : ControllerBase
    {
        private static ReplyService _replyService;

        public ReplyController(IDatabaseContext databaseContext)
        {
            _replyService = new ReplyService(databaseContext);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reply>>> GetAll()
        {
            try
            {
                return await _replyService.GetAllReplies();
            }
            catch (Exception ex)
            {
                Logger.Info("Error during Reply API GET " + ex.Message);
                return null;
            }
        }
        [HttpGet("{conversationId}")]
        public async Task<ActionResult<Reply>> GetConversationReplies(int id)
        {
            try
            {
                return await _replyService.GetConversationReplies(id);

            }
            catch (Exception ex)
            {
                Logger.Info("Error during Reply API GET " + ex.Message);
                return null;
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostNewReply([FromBody]Reply reply)
        {
            try
            {
                int res = await _replyService.CreateReply(reply);
                return Ok();
            }
            catch (Exception ex)
            {
                Logger.Error("Error during Reply API POST " + ex.Message);
                return BadRequest();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            try
            {
                Reply reply = await _replyService.GetReplyById(id);
                await _replyService.DeleteReply(reply);
                return Ok();
            }
            catch(Exception ex)
            {
                Logger.Error("error during Reply API DELETE " + ex.Message);
                return NotFound();

            }
        }

    }
}
