using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowerWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FenLeiController : ControllerBase
    {
        [HttpGet]
        public List<FenLei> GetFenLei()
        {
            List<FenLei> fenLeis = new List<FenLei>()
            {
                new FenLei(){ FenLeiTag ="电视剧",Id = 1},
                new FenLei(){ FenLeiTag ="电影",Id=2},
                new FenLei(){ FenLeiTag ="动漫",Id=3},
                new FenLei(){ FenLeiTag ="综艺",Id=4},
                new FenLei(){ FenLeiTag ="动画片",Id=5},
               
            };
            return fenLeis;
        }

    }
}
