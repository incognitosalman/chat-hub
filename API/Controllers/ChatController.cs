using Application.Common.Contracts.ExternalServices;
using Application.Models.Request;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly IChatHubService _chatHubService;

        public ChatController(IChatHubService chatHubService)
        {
            _chatHubService = chatHubService;
        }

        [Route("send-to-group")]
        [HttpPost]
        public IActionResult SendToGroup([FromBody] MessageToGroupRequest request)
        {
            _chatHubService.OnSendToGroupAsync(request.group, request.message);
            return Ok();
        }
    }
}