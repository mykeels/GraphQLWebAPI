using System.Web.Mvc;

namespace GraphQLWebAPI.Areas.GraphiQL
{
    public class GraphiQLAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "GraphiQL";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "GraphiQL_default",
                "GraphiQL/{action}/{id}",
                new { controller = "GraphiQL", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}