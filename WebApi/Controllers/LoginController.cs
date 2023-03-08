using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZhaoxiFlower.Common;
using ZhaoxiFlower.Model;
using ZhaoxiFlower.Model.Entitys;
using ZhaoxiFlower.Service;
using ZhaoxiFlower.Service.User.Dto;

namespace FlowerWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public IUserService _userService;
        public ICustomJWTService _customJWTService;
        public LoginController(IUserService userService, ICustomJWTService customJWTService)
        {
            _userService = userService;
            _customJWTService = customJWTService;
        }
        /// <summary>
        /// 获取验证码
        /// </summary>
        /// <param name="t">key</param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetValidateCodeImages(string t)
        {
            //调用CreateValidateString生成验证码
            var validateodeString = Tools.CreateValidateString();
            //将验证码计入缓存中，有效期5min
            MemoryHelper.SetMemory(t, validateodeString, 5);
            //接收图片返回二进制流
            byte[] buffer = Tools.CreateValidateCodeBuffer(validateodeString);
            //通过File操作对象 转化为一张图
            return File(buffer, @"image/jpeg");
        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Check(UserReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            //从缓存里面获取验证码
            var currCode = MemoryHelper.GetMemory(req.ValidateKey);
            if (string.IsNullOrEmpty(req.UserName) ||
                string.IsNullOrEmpty(req.Password) ||
                string.IsNullOrEmpty(req.ValidateKey)||
                string.IsNullOrEmpty(req.ValidateCode))
            {
                apiResult.Msg = "参数不能为空！";
            }
            else if (currCode == null)
            {
                apiResult.Msg = "验证码不存在，请刷新验证码";
            }
            else if (currCode.ToString() != req.ValidateCode)
            {
                apiResult.Msg = "验证码错误，请重新输入或刷新验证码重试";
            }
            else
            {
                UserRes user = _userService.GetUsers(req);
                if (string.IsNullOrEmpty(user.UserName))
                {
                    apiResult.Msg = "账号不存在，用户名或密码错误！";
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = _customJWTService.GetToken(user);
                }
            }
            return apiResult;
        }
        /// <summary>
        /// 注册方法
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost]
        public ApiResult Register(RegisterReq req)
        {
            ApiResult apiResult = new ApiResult() { IsSuccess = false };
            var currCode = MemoryHelper.GetMemory(req.ValidateKey);
            if (string.IsNullOrEmpty(req.UserName) || 
                string.IsNullOrEmpty(req.Password) || 
                string.IsNullOrEmpty(req.NickName) ||
                string.IsNullOrEmpty(req.ValidateKey) ||
                string.IsNullOrEmpty(req.ValidateCode))
            {
                apiResult.Msg = "参数不能为空！";
            }
            else
            {
                string msg = string.Empty;
                var res = _userService.RegisterUser(req, ref msg);
                 if (currCode == null)
                {
                    apiResult.Msg = "验证码不存在，请刷新验证码";
                }
                else if (currCode.ToString() != req.ValidateCode)
                {
                    apiResult.Msg = "验证码错误，请重新输入或刷新验证码重试";
                }
                if (!string.IsNullOrEmpty(msg))
                {
                    apiResult.Msg = msg;
                }
                else
                {
                    apiResult.IsSuccess = true;
                    apiResult.Result = _customJWTService.GetToken(res);
                }
            }
            return apiResult;
        }
    }
}
