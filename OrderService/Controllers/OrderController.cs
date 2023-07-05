using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;

namespace OrderService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ICapPublisher _capPublisher;

        public OrderController(ILogger<OrderController> logger, ICapPublisher capPublisher)
        {
            _logger = logger;
            _capPublisher = capPublisher;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public void CreateOrder()
        {
            //商業邏輯..
            //建立訂單完成
        }
    }
}