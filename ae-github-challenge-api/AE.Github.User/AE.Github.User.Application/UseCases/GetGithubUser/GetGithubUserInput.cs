using MediatR;

namespace AE.Github.User.Application.UseCases.GetGithubUser
{
    public class GetGithubUserInput : IRequest<GetGithubUserOutput>
    {
        public string UserName { get; set; }
    }
}
