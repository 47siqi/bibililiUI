using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Net.Sockets;
using System.Text;
using ZhaoxiFlower.Common;
using ZhaoxiFlower.Model;
using ZhaoxiFlower.Service;
using ZhaoxiFlower.Service.Config;
using ZhaoxiFlower.Service.Jwt;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
//设置JSON返回日期格式
builder.Services.AddControllers().AddNewtonsoftJson(Options => 
{
    Options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    Options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
}); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//注册缓存服务
builder.Services.AddMemoryCache();

//添加跨域策略
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", opt => opt.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().WithExposedHeaders("X-Pagination"));
});
//注册日志
builder.Logging.AddLog4Net("Config/log4net.Config");
//注册Automapper
builder.Services.AddAutoMapper(typeof(AutoMapperConfigs));
//注册JWT
builder.Services.Configure<JWTTokenOptions>(builder.Configuration.GetSection("JWTTokenOptions"));

//注册service层的服务
//builder.Services.AddTransient<IFlowerService, FlowerService>();
//builder.Services.AddTransient<IUserService, UserService>();
//builder.Services.AddTransient<IOrderService, OrderService>();
//builder.Services.AddTransient<ICustomJWTService, CustomJWTService>();
//通过Autofac注入
builder.Host
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new AutofacModuleRegister());
    });

//jwt校验
{
    //增加鉴权逻辑
    JWTTokenOptions tokenOptions = new JWTTokenOptions();
    builder.Configuration.Bind("JWTTokenOptions", tokenOptions);
    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)//Scheme
     .AddJwtBearer(options =>  //这里是配置的鉴权的逻辑
     {
         options.TokenValidationParameters = new TokenValidationParameters
         {
             //JWT有一些默认的属性，就是给鉴权时就可以筛选了
             ValidateIssuer = true,//是否验证Issuer
             ValidateAudience = true,//是否验证Audience
             ValidateLifetime = true,//是否验证失效时间
             ValidateIssuerSigningKey = true,//是否验证SecurityKey
             ValidAudience = tokenOptions.Audience,//
             ValidIssuer = tokenOptions.Issuer,//Issuer，这两项和前面签发jwt的设置一致
             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey))//拿到SecurityKey 
         };
     });
}

//配置CORS，处理跨域问题
//string[] urls = new[] { "http://localhost:8080/" };  //允许访问后端接口的前端域名

//builder.Services.AddCors(options =>
//options.AddDefaultPolicy(builder =>
//builder.WithOrigins(urls)
//    .AllowAnyMethod()
//    .AllowAnyHeader()
//    .AllowCredentials()));

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("cors", builder =>
//    {
//        builder.WithMethods("GET", "POST", "HEAD", "PUT", "DELETE", "OPTIONS")
//    //.AllowCredentials()//指定处理cookie
//    .AllowAnyOrigin(); //允许任何来源的主机访问
//    });
//});


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
#region 鉴权授权
app.UseAuthentication();
app.UseAuthorization();
#endregion
//app.UseCors();
//app.UseHttpsRedirection();

//app.UseRouting();
//app.UseAuthorization();
//app.UseAuthentication();
//配置Cors
//app.UseCors("cors");
//app.UseEndpoints(endpoints =>
//{
//   endpoints.MapControllers();
//});

//this is master
//This is git text;
app.MapControllers();
//使用跨域策略
app.UseCors("CorsPolicy");
app.Run();


//github 测试
