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
using GraphQLWebAPI.Filters;

namespace GraphQLWebAPI.Controllers
{
    public class GraphController: ApiController
    {
        [HttpPost]
        [Route("~/api/graph")]
        [GraphType(typeof(BooksQuery))]
        public async Task<IHttpActionResult> Post([FromBody] ExecutionResult result)
        {
            var json = new DocumentWriter(indent: true).Write(result);

            return Ok(JObject.Parse(json));
        }
    }
}