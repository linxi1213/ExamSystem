using ExamSystem.WebApi.entities;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamSystem.WebApi.Common_Interface
{
    public interface Operation
    {
        Task<JToken> CreateRequest(string uri,IResult input);

        Task<string> UpdateRequest(string uri,IResult input);

        Task<string> DeleteRequest(string uri, entity<long> input);

        Task<JToken> GetRequest(string uri, entity<long> input);

        Task<List<JToken>> GetAllRequest(string uri);
    }
}
