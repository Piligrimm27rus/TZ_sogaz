using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Telegram.Bot.Types;
using Telegram.Bot;
using TZ_sogaz.Services;

namespace TZ_sogaz.Controllers
{
    [ApiController]
    [Route("api/bot")]
    public class BotController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] Update update)
        {
            BotActionController.ChatMessage(update);

            return Ok();
        }
    }
}
