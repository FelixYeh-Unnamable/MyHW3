using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyHW3.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace MyHW3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly TokenBuild _tokenBuild;
        private readonly string tokenUri = $"https://tdx.transportdata.tw";
        private readonly string apiUri = $"https://tdx.transportdata.tw/api/basic/v3/Rail/TRA/TrainLiveBoard/TrainNo/";
        public ValuesController(TokenBuild tokenBuild)
        {
            _tokenBuild = tokenBuild;
        }



        //取得TDX API資料
        [HttpGet]
        public LiveBoard Get()
        {
            var accessToken = _tokenBuild.GetToken(tokenUri).Result;
            var apiResponse = _tokenBuild.Get(GetParameters(), apiUri, accessToken.access_token).Result;

            var collection = JsonConvert.DeserializeObject<LiveBoard>(apiResponse);

            return collection;
        }

        private Dictionary<string, string> GetParameters()
        {
            return new Dictionary<string, string>()
            {
                { $"$select","" },
                { $"$filter",""},
                { $"$orderby","StationID"},
                { $"$top",""},
                { $"$skip",""},
                { $"health",""},
                { $"$format","JSON"},
            };
        }



    }
}
