using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoxiFlower.Model;
using ZhaoxiFlower.Model.Entitys;
using ZhaoxiFlower.Service;

namespace FlowerWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]  //授权标记
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private IOrderService _oderServer;
        public OrderController(IOrderService oderServer, ILogger<OrderController> logger)
        {
            _oderServer = oderServer;
            _logger = logger;
        }
        /// <summary>
        /// 创建订单
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult CreateOrder(OrderReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            if (req.FlowerId == 0) 
            {
                apiResult.Msg = "参数不能为空";
            }
            else 
            {    
                string msg = string.Empty;
                long userId = Convert.ToInt32(HttpContext.User.Claims.ToList()[0].Value);
                bool res = _oderServer.CreateOrder(req, userId, ref msg);
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else
                {
                    apiResult.IsSuccess = res;
                }
            }
            return apiResult;
        }
        
        [HttpPost]
        public ApiResult GetOrder()
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = true };
            try
            {
                long userId = Convert.ToInt32(HttpContext.User.Claims.ToList()[0].Value);
                apiResult.Result = _oderServer.GetOrder(userId);
                _logger.LogInformation("this is GetOrder---");
            }
            catch (Exception ex)
            {
                apiResult.IsSuccess = false;
                apiResult.Msg = ex.Message;
            }
            return apiResult;
        }
    }
}
