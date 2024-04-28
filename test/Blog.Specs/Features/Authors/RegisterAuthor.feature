# language: pt
Funcionalidade: Registrar Autor

  Cenário: Sucesso ao enviar request válido
    Dado que o usuário faz uma requisição válida para a rota de cadastro de autores
    Quando ele envia os dados do autor no corpo da requisição
    Então a API registra o novo autor e retorna uma resposta de sucesso com status 201

  Cenário: Erro ao enviar request inválido
    Dado que o usuário faz uma requisição inválida para a rota de cadastro de autores
      | Name | Email             |
      | J    | email@contoso.com |
    Quando ele envia os dados do autor no corpo da requisição
    Então a API retorna uma resposta de erro com status 422
