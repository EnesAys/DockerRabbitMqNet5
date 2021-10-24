using Microsoft.AspNetCore.Mvc;
using Net5RabbitMqProducerApi.Services;

namespace Net5RabbitMqProducerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NameController : ControllerBase
    {
        private readonly IRabbitMqService _rabbitMqService;

        public NameController(IRabbitMqService rabbitMqService)
        {
           _rabbitMqService = rabbitMqService;
        }
        [HttpGet]
        public IActionResult Get(string name)
        {
            _rabbitMqService.SendNameToQueue(name);
            return  Ok("Success");
        }
    }
}
