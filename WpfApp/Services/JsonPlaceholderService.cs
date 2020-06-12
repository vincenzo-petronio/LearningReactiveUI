using DynamicData;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json; // from .NETCore 3 !!!
using System.Threading.Tasks;
using WpfApp.Models;

namespace WpfApp.Services
{
    public class JsonPlaceholderService : IDataService
    {
        private const string ApiTodo = "http://jsonplaceholder.typicode.com/todos";

        public async Task<IEnumerable<Todo>> GetTodoItems()
        {
            var result = Array.Empty<Todo>();

            var httpWebReq = (HttpWebRequest)WebRequest.Create(new Uri(ApiTodo));
            httpWebReq.Method = "GET";

            using (WebResponse webRes = await httpWebReq.GetResponseAsync())
            using (StreamReader resStream = new StreamReader(webRes.GetResponseStream()))
            {
                var jsonResult = await resStream.ReadToEndAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                };
                var jsonToObjResult = JsonSerializer.Deserialize<Todo[]>(jsonResult, options);
                result = jsonToObjResult;
            }

            return result;
        }
    }
}
