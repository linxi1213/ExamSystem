using ExamSystem.WebApi.entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.WebApi.Server
{
    public class TestpaperServer : UserWebRequest
    {
        public TestpaperServer(string login_Token) : base(login_Token)
        {

        }


        public async Task<JToken> UpdataTestActive(string uri, entity<long> input)
        {

          
            var result = await client.PostAsync(uri + "?id="+ input.id,null);
            JToken re = await Getsuccess(result);

            return re;


        }
    }
}
