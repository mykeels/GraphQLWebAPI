using System;
using System.Linq;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using GraphQL;
using GraphQL.Types;
using System.Collections.Generic;

namespace GraphQLWebAPI.Filters
{
    public class GraphTypeAttribute : FilterAttribute, IActionFilter
    {
        private readonly string _parameterName;
        private readonly Type _parameterType;
        public GraphTypeAttribute(Type type, string parameterName = null)
        {
            this._parameterName = parameterName;
            this._parameterType = type;
        }

        public async Task<HttpResponseMessage> ExecuteActionFilterAsync(HttpActionContext actionContext, CancellationToken cancellationToken, Func<Task<HttpResponseMessage>> continuation)
        {
            string query = Convert.ToString(actionContext.ActionArguments.ToArray().First().Value);
            var result = await new DocumentExecuter().ExecuteAsync((options) =>
            {
                options.Schema = new Schema() { Query = (IObjectGraphType)Activator.CreateInstance(_parameterType) };
                options.Query = query;
            });
            _checkForErrors(result);
            actionContext.ActionArguments[_parameterName ?? actionContext.ActionArguments.ToArray().First().Key] = result;
            return await continuation();
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