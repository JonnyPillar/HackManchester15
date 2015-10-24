using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using Hack.Domain.Interfaces;
using Hack.Server.ApiControllers;

namespace Hack.Server.Attributes
{
    public sealed class CustomAuthoriseAttribute : AuthorizeAttribute

{
    public override void OnAuthorization(HttpActionContext actionContext)
    {
        var applicationContext = ApplicationContext(actionContext);

        if (!applicationContext.User.IsAuthorised)
        {
            // user is unauthorized or does not have adequate permissions to access the resource.
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
    }

    private static IApplicationContext ApplicationContext(HttpActionContext actionContext)
    {
        var controller = ((BaseApiController) actionContext.ControllerContext.Controller);
        var applicationContext = controller.ApplicationContext;
        applicationContext.InitialiseFrom(actionContext.Request);
        return applicationContext;
    }
}
}