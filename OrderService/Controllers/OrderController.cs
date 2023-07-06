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

        [HttpPost(Name = "CreateOrder")]
        public void CreateOrder()
        {
            //商業邏輯..
            //建立訂單完成
            SendSmsDto sendSmsDto = new () { PhoneNumber = "0987887887", Content = "使用.NET core CAP 實現微服務事件發送" };
            _capPublisher.Publish("SendSms",sendSmsDto);
        }
    }

    public record SendSmsDto
    {
        public string PhoneNumber { get; set; }
        public string Content { get; set; }
    }
}