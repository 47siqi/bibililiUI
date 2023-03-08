using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoxiFlower.Model;
using ZhaoxiFlower.Service.FileCard;
using ZhaoxiFlower.Service.FileCard.Dot;

namespace FlowerWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FlieCardController : ControllerBase
    {
        private readonly IFileCardService _fileCardService;

        public FlieCardController(IFileCardService fileCardService)
        {
            _fileCardService = fileCardService;
        }
        [HttpPost]
        public ApiResult GetFlieCard(FileCardReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = true };
            apiResult.Result = _fileCardService.GetFileCards(req);
            return apiResult;
        }
    }
}
