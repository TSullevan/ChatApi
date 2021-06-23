using System.Threading.Tasks;
using ChatApi.dtos;
using Microsoft.AspNetCore.Mvc;
using PusherServer;

namespace ChatApi.Controllers
{
    [Route(template: "api")]
    [ApiController]
    public class ChatController : Controller
    {
        [HttpPost(template: "messages")]
        public async Task<ActionResult> Message(MessageDTO dto)
        {
            var options = new PusherOptions
            {
                Cluster = "mt1",
                Encrypted = true
            };

            var pusher = new Pusher(
              appId: "1224143",
              appKey: "7e1d288d38eb4c3cfc27",
              appSecret: "cbf89a7c01d41731691a",
              options);

            await pusher.TriggerAsync(
              channelName: "ChatApi",
              eventName: "message",
              data: new
              {
                  username = dto.Username,
                  message = dto.Message
              });// Task<ITriggerResult>

            return Ok(new string[] { });
        }
    }
}