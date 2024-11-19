# Sistema de Delivery  


## 📚 **Sobre o Projeto**  
O **Sistema de Delivery** é uma plataforma para gerenciar pedidos de entrega, garantindo uma experiência eficiente e intuitiva para **empresas**, **consumidores** e **entregadores**. Com funcionalidades de rastreamento em tempo real e arquitetura sólida, o projeto foi desenvolvido para ser escalável e fácil de manter.  

### Funcionalidades principais:  
- **Cadastro de Usuários**: Permite criar contas para empresas, consumidores e entregadores.  
- **Criação de Pedidos**: Empresas e consumidores podem criar pedidos rapidamente.  
- **Rastreamento em Tempo Real**: Visualização ao vivo do status e da localização do pedido.  
- **Gerenciamento de Entregas**: Acompanhamento completo das entregas pelas empresas e entregadores.  

---

## 🏗️ **Arquitetura do Projeto**  

O sistema foi desenvolvido utilizando **Clean Architecture** e **Domain-Driven Design (DDD)** para garantir:  
- **Manutenibilidade**: Facilita a adição de novas funcionalidades.  
- **Separação de Responsabilidades**: Cada camada possui funções específicas e bem definidas.  
- **Escalabilidade**: Uma base sólida para crescimento futuro do sistema.  

### Estrutura Base da Arquitetura
```plaintext
src/
├── Backend/
    ├── AppDelivery.API/ # Camada de entrada da aplicação (controllers, filtros e middlewares)
    │   ├── Connected Services/
    │   ├── Dependencies/
    │   ├── Properties/
    │   ├── Controllers/ # Controladores para as rotas HTTP
    │   ├── Filters/ # Filtros personalizados para requisições
    │   ├── Middleware/ # Middlewares customizados
    │   ├── AppDelivery.API.http/ # Arquivos de teste HTTP
    │   ├── appsettings.json/ # Configurações da aplicação
    │   ├── Program.cs/ # Inicialização da aplicação
    │
    ├── AppDelivery.Application/ # Casos de uso e lógica de aplicação
    │   ├── Dependencies/
    │   ├── Services/ # Serviços auxiliares para lógica de negócios
    │   ├── UseCases/ # Implementações de casos de uso
    │   ├── DependencyInjectionExtension.cs/ # Configuração de injeção de dependência
    │   ├── IConfiguration.cs/ # Interface de configuração
    │
    ├── AppDelivery.Communication/ # Comunicação com o cliente
    │   ├── Dependencies/
    │   ├── Requests/ # Estruturas para entrada de dados
    │   ├── Responses/ # Estruturas para saída de dados
    │
    ├── AppDelivery.Domain/ # Regras de negócio e entidades principais
    │   ├── Dependencies/
    │   ├── Entities/ # Entidades principais
    │   ├── Repositories/ # Interfaces de repositórios
    │
    ├── AppDelivery.Exceptions/ # Gerenciamento de exceções
    │   ├── Dependencies/
    │   ├── ExceptionsBase/ # Classes base para exceções
    │   ├── ResourceMessagesException.es.resx/ # Mensagens de exceção em espanhol
    │   ├── ResourceMessagesException.pt-BR.resx/ # Mensagens de exceção em português
    │   ├── ResourceMessagesException.resx/ # Mensagens de exceção padrão
    │
    ├── AppDelivery.Infrastructure/ # Infraestrutura do sistema
        ├── Dependencies/
        ├── DataAccess/ # Acesso a dados e configurações de banco
        ├── Extensions/ # Extensões auxiliares
        ├── Migrations/ # Arquivos de migração do banco de dados
        ├── DependencyInjectionExtension.cs/ # Configuração de injeção de dependência para a infraestrutura

```
![Arquitetura DDD](https://github.com/user-attachments/assets/5b732dee-79ba-4373-bd9a-061dca35c45d)

---

## 🛠️ **Tecnologias Utilizadas**   
- **Tecnologias**: .NET, Dapper, Entity Framework, FluentMigrator, Mapper, Repository Pattern, Dependency Injection, CQRS, Factory, Singleton Pattern
- **Banco de Dados**: MySQL
- **Rastreamento em Tempo Real**: WebSockets, API do Google
- **Documentação da API**: Swagger

---

## 📄 **Documentação da API**  

Os endpoints da API estão documentados no **Swagger**.

<details>
   <summary style="cursor: pointer; font-weight: bold; color: #007bff; background-color: #f8f9fa; padding: 10px; border-radius: 5px;">
     📸 Clique aqui para visualizar os Endpoints do Swagger
   </summary>
   <img src="https://github.com/user-attachments/assets/28873286-2fdb-4245-8072-361de4cc7ff6" alt="Swagger Endpoints" style="max-width:100%;height:auto;">
</details>

---

## 🚀 **Como Executar o Projeto**  

1. Clone o repositório:  
   ```bash
   git clone https://github.com/luisfelipeprs/AppDelivery_Backend.git
   cd AppDelivery_Backend
   ```  
3. **Restaure as dependências:**

   Navegue até a pasta do projeto e execute o comando:

   ```bash
   dotnet restore
   ```
     
4. **Configurar o banco de dados:**

   Crie um banco de dados MySQL e configure a string de conexão no arquivo `appsettings.json` dentro da pasta `AppDelivery.Api`.

   ```json
    {
      "ConnectionStrings": {
        "ConnectionMySql": "Server=localhost;Database=appdeliverydb;Uid=root;Pwd=root;"
      },
      "Settings": {
        "Jwt": {
          "SigningKey": "wwwwwwwwwwwwwwwwwwwwwwwwwwwwwwww",
          "ExpirationTimeMinutes": 1000
        }
      }
    }

   ```
5. **Inicie o servidor:**

   Após configurar o banco de dados, inicie o servidor localmente:

   ```bash
   dotnet run --project \src\Backend\AppDelivery.API
   ```

   O sistema estará disponível em `http://localhost:5027`.

4. Acesse o Swagger para testar os endpoints: `http://localhost:5027/swagger`.  

---

## 📂 **Contribuição**  

Contribuições são bem-vindas! Sinta-se à vontade para abrir uma issue ou enviar um pull request.  

---

## 📧 **Contato**  

Para dúvidas ou suporte, entre em contato através de [Meu LinkedIn](https://www.linkedin.com/in/luisfelipeprs/).  

