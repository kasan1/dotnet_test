using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Agro.Shared.Api.Controllers
{
    [Route("")]
    public class MediatrControllerBase : BaseController
    {
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??= (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator));
    }
}
