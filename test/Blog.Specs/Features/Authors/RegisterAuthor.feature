# language: pt

Funcionalidade: Registrar Autor

    Cenário: Sucesso ao enviar request válido
        Dado que o usuário faz uma requisição para a rota de cadastro de autores
        Quando ele envia os dados do autor no corpo da requisição
        Então a API registra o novo autor e retorna uma resposta de sucesso com status 201