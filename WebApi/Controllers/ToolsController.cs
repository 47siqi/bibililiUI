
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoxiFlower.Common;

namespace FlowerWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ToolsController : ControllerBase
    {
        [HttpGet]
        //初始化数据库
        public void InitDatabase()
        {
            DbComText.InitDataBase();
        }
    }
}
