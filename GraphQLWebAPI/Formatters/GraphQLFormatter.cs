using System;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;
using System.IO;
using System.Threading;
using System.Net.Http;
using GraphQL;
using GraphQL.Types;

namespace GraphQLWebAPI.Formatters
{
    public class GraphQLFormatter : BufferedMediaTypeFormatter
    {
        public GraphQLFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/graphql"));
        }

        public override bool CanReadType(Type type)
        {
            return type == typeof(string) || type == typeof(ExecutionResult) || type is IObjectGraphType;
        }

        public override bool CanWriteType(Type type)
        {
            return type == typeof(string) || type == typeof(ExecutionResult) || type is IObjectGraphType;
        }

        public override object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger, CancellationToken cancellationToken)
        {
            StreamReader reader = new StreamReader(readStream);
            string str = reader.ReadToEnd();
            return str;
        }
    }
}