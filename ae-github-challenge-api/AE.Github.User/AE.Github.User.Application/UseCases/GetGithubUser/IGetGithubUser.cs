using MediatR;

namespace AE.Github.User.Application.UseCases.GetGithubUser
{
    internal interface IGetGithubUser : IRequestHandler<GetGithubUserInput, GetGithubUserOutput>
    {

    }
}
