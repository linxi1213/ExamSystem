using ExamSystem.WebApi.Common_Interface;
using ExamSystem.WebApi.entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.WebApi
{
    /// <summary>
    /// 公用HttpClient类
    /// </summary>
    public class UserWebRequest : Operation
    {
        public HttpClient client;
       // private string login_Token { get ; set ;}
       // private StringContent input;

        public UserWebRequest(string login_Token)
        {
            client = new HttpClient();
            //this.login_Token = login_Token;
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + login_Token);
        }

        /// <summary>
        /// 将输入转为json格式
        /// </summary>
        /// <param name="Dto"></param>
        /// <returns></returns>
        private StringContent GetJson(IResult Dto)
        {
            var js = JsonConvert.SerializeObject(Dto);

            var input = new StringContent(js);

            input.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json") { CharSet = "utf-8" };

            return input;
        }

        public virtual async Task<JToken> CreateRequest(string uri, IResult input)
        {
          
                var inp = GetJson(input);
                var result =await client.PostAsync(uri, inp);
                JToken re = await Getsuccess(result);

                return re;
                //if (result.IsSuccessStatusCode == false)
                //{ return re["error"]["message"].ToString(); }
                // else
                //{ return result.StatusCode.ToString(); }


        }
       
        public virtual async Task<string> DeleteRequest(string uri, entity<long> input)
        {
            //var result = await client.DeleteAsync(uri + "?Id=" + input.id.ToString()  );
            //var inp = new FormUrlEncodedContent(new Dictionary<string, string>{
            //    { "Id" ,"10" }  
            //});
            //var httpRequestMessage = new HttpRequestMessage()
            //{
            //    Method = HttpMethod.Delete,
            //    RequestUri = new Uri(uri),
            //    Content = inp
            //};
                string uris = uri + "?Id=" + input.id;
                var result = await client.DeleteAsync(uris);
                if (!result.IsSuccessStatusCode)
                { return "请求失败，查看是否用于权限"; }
                else
                { return result.StatusCode.ToString(); }
       
            
        }

        public virtual async Task<JToken> GetRequest(string uri, entity<long> input)
        {
                var result = await client.GetAsync(uri + "?Id=" + input.id );
                JToken re = await Getsuccess(result);
                if (result.IsSuccessStatusCode == false)
               { return re["error"]; }
                 return re["result"];  
 
        }

        public virtual async Task<JToken> GetRequest(string uri)
        {
            var result = await client.GetAsync(uri);
            JToken re = await Getsuccess(result);
            if (result.IsSuccessStatusCode == false)
            { return re["error"]; }
            return re["result"];

        }


        public virtual async Task<string> UpdateRequest(string uri, IResult input)
        {
            
                var inp = GetJson(input);

                var result = await client.PutAsync(uri, inp);

                JToken re =await Getsuccess(result);

                if (result.IsSuccessStatusCode == false)
                { return re["error"]["message"].ToString(); }
                else
                { return result.StatusCode.ToString(); }
         
        }

        public  async Task<JToken> Getsuccess(HttpResponseMessage result)
        {
            string str = await result.Content.ReadAsStringAsync();

            var js = JToken.Parse(str);


            return js;
        }

        public virtual async Task<List<JToken>> GetAllRequest(string uri)
        {
           
                var result = await client.GetAsync(uri);
                JToken re = await Getsuccess(result);
                List<JToken> users = re["result"]["items"].ToList<JToken>();

                return users;
       
        }
    }
}
