using CsvHelper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReactWebBlogger.Application.DTOs;
using ReactWebBlogger.Application.Services;
using ReactWebBlogger.Contracts.Services;
using System.Formats.Asn1;
using System.Globalization;
using System.Text;

namespace ReactWebBlogger.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService<MessageDto> _messageService;

        public MessageController(IMessageService<MessageDto> messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _messageService.GetAllAsync();
            return Ok(blogs);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var blog = await _messageService.GetByIdAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            await _messageService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("DownloadCsv")]
        public async Task<IActionResult> DownloadMessagesAsCsv()
        {
            var messages = await _messageService.GetAllAsync();

            var stringBuilder = new StringBuilder();
            using (var csvWriter = new CsvWriter(new StringWriter(stringBuilder), CultureInfo.InvariantCulture))
            {
                csvWriter.WriteRecords(messages);
            }

            return File(Encoding.UTF8.GetBytes(stringBuilder.ToString()), "text/csv", "messages.csv");
        }

        // POST api/message
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] MessageDto messageDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                await _messageService.AddAsync(messageDto);
                return Ok("Thank you for your message. I will contact you as soon as possible.");
            } catch (Exception) { 
                return StatusCode(500, "An unexpected error occurred. You can contact me directly via my e-mail address (hakanttek@gmail.com).");
            }
        }
    }
}
