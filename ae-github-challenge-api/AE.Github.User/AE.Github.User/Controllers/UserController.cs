using AE.Github.User.Application.UseCases.GetGithubUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AE.Github.User.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{user}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetGithubUserOutput))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser([FromRoute] string user, CancellationToken cancellationToken)
        {
            var input = new GetGithubUserInput
            {
                UserName = user
            };
            var result = await _mediator.Send(input, cancellationToken);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
