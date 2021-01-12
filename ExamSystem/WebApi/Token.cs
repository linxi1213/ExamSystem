using ExamSystem.WebApi.entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.WebApi
{
    public class Token
    {
        public string login_Token;

        public string login_Id;

        public user us;

        public async Task<string> GetToken(user us)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(us);

                var input = new StringContent(json);

                input.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("Application/json") { CharSet = "utf-8" };

                var result =await client.PostAsync(Uris.BaseUrl + Uris.loginToken, input);

                string str = await result.Content.ReadAsStringAsync();
               
                var js = JToken.Parse(str);

                if(result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    return js["error"]["message"].ToString();
                }

                login_Token = js["result"]["accessToken"].ToString();
                login_Id = js["result"]["userId"].ToString();
                this.us = us;
                return login_Token;
            }
           
        }
    }
}
