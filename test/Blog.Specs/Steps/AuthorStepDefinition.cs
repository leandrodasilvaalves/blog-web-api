using System.Net;

using Blog.Api.Application.Authors.RegisterAuthors;
using Blog.Api.Infra.Data.Context.Mongo;
using Blog.Api.Infra.Data.Models;
using Blog.Specs.Clients;

using FluentAssertions;

using MongoDB.Bson;

using Refit;

using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace Blog.Specs.Steps;

[Binding]
public sealed class AuthorStepDefinition(ScenarioContext scenarioContext, IMongoDbContext<AuthorDbModel> mongo)
{
    private readonly ScenarioContext _scenarioContext = scenarioContext;
    private readonly IAuthorsHttpClient _client = BaseHttpClient.Create<IAuthorsHttpClient>();
    private readonly IMongoDbContext<AuthorDbModel> _mongo = mongo;

    [Given("que o usuário faz uma requisição válida para a rota de cadastro de autores")]
    public void Given_That_The_User_Makes_A_Request_For_The_Author_Registration_Route()
    {
        var request = new RegisterAuthorRequest { Name = "João da Silva", Email = "contato@contoso.com" };
        _scenarioContext["request"] = request;
    }

    [Given("que o usuário faz uma requisição inválida para a rota de cadastro de autores")]
    public void Given_Than_User_Makes_A_Invalid_Request_For_The_Author_Registration_Route(Table table)
    {
        var request = table.CreateInstance<RegisterAuthorRequest>();
        _scenarioContext["request"] = request;
    }

    [Given("que o usuário tenta cadastrar um autor com um e-mail já existente")]
    public void Given_That_The_User_Tries_To_Register_An_Existing_Email(Table table)
    {
        var request = table.CreateInstance<RegisterAuthorRequest>();
        _scenarioContext["request"] = request;

        var mongoDbModel = new AuthorDbModel { Id = $"{Guid.NewGuid()}", Email = request.Email };
        _mongo.Collection.InsertOne(mongoDbModel);
    }

    [Given("que o usuário tenta cadastrar um autor com um nome já existente")]
    public void Given_That_The_User_Tries_To_Register_An_Existing_Name(Table table)
    {
        var request = table.CreateInstance<RegisterAuthorRequest>();
        _scenarioContext["request"] = request;

        var mongoDbModel = new AuthorDbModel { Id = $"{Guid.NewGuid()}", Name = request.Name };
        _mongo.Collection.InsertOne(mongoDbModel);
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

    [Then("a API retorna uma resposta de erro com status 422")]
    public void Then_The_Api_Returns_A_Response_Error_With_StatusCode_Unprocessable_Entity()
    {
        var response = _scenarioContext.Get<ApiResponse<RegisterAuthorResponse>>("response");

        response.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);
        response.Error.Content.Should().NotBeNullOrEmpty();
    }
}