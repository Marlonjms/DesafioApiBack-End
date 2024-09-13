Passo a Passo para Clonar e Rodar o Projeto ASP.NET Core no Visual Studio 2022



Banco de dados:  postgree
IDE: Viusal Studio 2022




1	Clone o Repositório:

•	No terminal do Visual Studio, execute o comando:
  Ex:  git clone https://github.com/Marlonjms/DesafioApiBack-End.git
•	Entre no diretório do projeto:
  Ex: cd DesafioApiBack-End

2 Restaurar Dependências:
•	Execute o comando para restaurar as dependências do projeto:
  dotnet restore
  
3  Abrir o Projeto no Visual Studio:
•	No Visual Studio, clique em "File" (Arquivo) no menu superior.
•	Selecione "Open" (Abrir) e depois "Project/Solution" (Projeto/Solução).
•	Navegue até o diretório onde você clonou o repositório (DesafioApiBack-End).
•	Selecione o arquivo de solução .sln e clique em "Open" (Abrir).
•	O Visual Studio irá carregar o projeto.


4 Configurar a Conexão ao Banco de Dados:
•	No arquivo appsettings.json, configure a string de conexão para o seu banco de dados. Exemplo:
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Database=DesafioApiBackEnd;Username=seu_usuario;Password=sua_senha"
}


5 Criar Migrações e Atualizar o Banco de Dados:
•	Clique na guia "Ferramentas".
•	Selecione "Gerenciador de Pacotes NuGet".
•	Depois clique em "Console do Gerenciador de Pacotes".
•	Execute o comando para criar uma nova migração:
  Add-Migration Criandobancodedados

•	Após criar a migração, execute o comando para atualizar o banco de dados:
  Update-Database
  
6  Executar o Projeto:
•	Clique no botão "Play Verde" (Iniciar Sem Depurar) no Visual Studio.
•	O projeto será iniciado e, o Swagger, será aberto para que você possa testar as APIs.
