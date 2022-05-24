﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BandrBackEnd.DataAccess;
using BandrBackEnd.Models;

namespace BandrBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : Controller
    {
        private readonly IMessageRepository _messageRepository;

        public MessageController(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        [HttpGet("participant/{participantId}")]

        public ActionResult getMessagesByPartId(int participantId)
        {
            List <Message> messages = _messageRepository.GetMessagesByPartId (participantId);

            if(messages == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(messages);
            }
        }

        [HttpGet("{id}")]
        public ActionResult getMessage(int id)
        {
            Message message = _messageRepository.GetMessageById(id);
            if (message == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(message);
            }
        }

        [HttpPost]
        public ActionResult createMessage(Message newMessage)
        {
            if(newMessage == null)
            {
                return NotFound();
            }
            else
            {
                _messageRepository.createMessage(newMessage);
                return Ok();
            }
        }

        [HttpPatch("{id}")]

        public ActionResult updateMessage(int id, Message updateMessage)
        {
            Message message = _messageRepository.GetMessageById(id);
            if (message != null)
            {
                _messageRepository.updateMessage(message);
                return Ok(updateMessage);
            }
            else
            {
                return BadRequest(updateMessage);
            }
        }

        [HttpDelete("{id}")]

        public ActionResult deleteMessage(int id)
        {
            try
            {
                _messageRepository.deleteMessage(id);
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest("DELETE FAILED");
            }
        }
    }
}
