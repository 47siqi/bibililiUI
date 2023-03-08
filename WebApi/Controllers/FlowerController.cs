using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoxiFlower.Model;
using ZhaoxiFlower.Service;
using ZhaoxiFlower.Service.Flower.Dto;

namespace FlowerWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]   
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerService _flowerService;
        public FlowerController(IFlowerService flowerService) 
        { 
            _flowerService = flowerService;
        } 
        [HttpPost]
        public ApiResult GetFlowers(FlowerReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = true };
            apiResult.Result = _flowerService.GetFlowers(req);
            return apiResult;
        }
    }
}
