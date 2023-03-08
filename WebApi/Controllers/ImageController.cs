using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FlowerWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        //获取图片列表的方法
        [HttpGet]
        public List<ImageModel> GetImages()
        {
            List <ImageModel> list = new List<ImageModel>()
            { 
                new ImageModel(){ ImageUrl="/images/banners/banner1.jpg",CouresUrl="http://localhost:8080/"},
                new ImageModel(){ ImageUrl="/images/banners/banner2.jpg",CouresUrl="http://localhost:8080/"},
                new ImageModel(){ ImageUrl="/images/banners/banner3.jpg",CouresUrl="http://localhost:8080/"},

            };
            return list;
        }
    }
}
