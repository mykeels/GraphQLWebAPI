using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using GraphQL;
using GraphQL.Types;
using System.Threading.Tasks;
using GraphQL.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using GraphQLWebAPI.Queries;

namespace GraphQLWebAPI.Controllers
{
    public class GraphController: ApiController
    {
        [HttpPost]
        [Route("~/api/graph")]
        public async Task<IHttpActionResult> Post([FromBody] string query)
        {
            var result = await new DocumentExecuter().ExecuteAsync((options) =>
            {
                options.Schema = new Schema() { Query = new BooksQuery() };
                options.Query = query;
            });
            _checkForErrors(result);
            var json = new DocumentWriter(indent: true).Write(result);

            return Ok(JObject.Parse(json));
        }

        private void _checkForErrors(ExecutionResult result)
        {
            if (result.Errors?.Count > 0)
            {
                var errors = new List<Exception>();
                foreach (var error in result.Errors)
                {
                    var ex = new Exception(error.Message);
                    if (error.InnerException != null)
                    {
                        ex = new Exception(error.Message, error.InnerException);
                    }
                    errors.Add(ex);
                }
                throw new AggregateException(errors);
            }
        }
    }
}