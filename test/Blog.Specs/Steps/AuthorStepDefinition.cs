using System.Net;

using Blog.Api.Application.Authors.RegisterAuthors;
using Blog.Specs.Clients;

using FluentAssertions;

using Refit;

using TechTalk.SpecFlow;

namespace Blog.Specs.Steps;

[Binding]
public sealed class AuthorStepDefinition(ScenarioContext scenarioContext)
{
    private readonly ScenarioContext _scenarioContext = scenarioContext;
    private readonly IAuthorsHttpClient _client = BaseHttpClient.Create<IAuthorsHttpClient>();

    [Given("que o usuário faz uma requisição para a rota de cadastro de autores")]
    public void Given_That_The_User_Makes_A_Request_For_The_Author_Registration_Route()
    {
        var request = new RegisterAuthorRequest { Name = "João da Silva", Email = "contato@contoso.com" };
        _scenarioContext["request"] = request;
    }

    [When("ele envia os dados do autor no corpo da requisição")]
    public async Task When_He_Sends_The_Authors_Data_In_The_Body_Of_The_Request()
    {
        var request = _scenarioContext.Get<RegisterAuthorRequest>("request");
        var response = await _client.RegisterAsync(request);
        _scenarioContext["response"] = response;
    }

    [Then("a API registra o novo autor e retorna uma resposta de sucesso com status 201")]
    public void Then_The_API_Registers_The_New_Author_And_Returns_A_Success_Response_With_Status_Created()
    {
        var request = _scenarioContext.Get<RegisterAuthorRequest>("request");
        var response = _scenarioContext.Get<ApiResponse<RegisterAuthorResponse>>("response");
        var content = response.Content;

        content.Id.Should().NotBeNullOrWhiteSpace();
        content.Name.Should().Be(request.Name);
        content.Email.Should().Be(request.Email);
        content.CreatedAt.Should().BeBefore(DateTime.UtcNow);
        response.StatusCode.Should().Be(HttpStatusCode.Created);
    }
}