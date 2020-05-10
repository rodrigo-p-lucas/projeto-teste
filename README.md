# Projeto-Teste
Projeto teste de manutenção de produto através de integração

## Objetivo
O objetivo este projeto é desenvolver uma integração entre aplicações, onde uma seja um WebAPI e a outra uma aplicação cliente(seja desktop ou web).
Para o projeto atual, foi escolhido uma aplicação desktop.

## Montagem de ambiente
Para realizar testes e depurações no projeto, será necessária a alteração de algumas configurações dele.

### Aplicação Servidor(WebAPI)
Depois da realização do download do projeto, é necessário realizar o build para que o NuGet atualize e baixe as referencias de projetos externos.
Além disso, o projeto não aplica as migrações do EntityFrameworkCore automaticamente, então é necessário realiza-las manualmente.
Portanto, vá no menu Exibir > Outras Janelas > Console do Gerenciador de Pacotes, selecione como projeto padrão o projeto ProjetoTeste.Persistencia, e depois, dentro do console, digite `restore-database`.
Isso criará uma base de dados chamada ProjetoTesteAPI no seu ambiente local(necessário ter essa configuração no seu ambiente).

### Aplicação Cliente(Console)
Esta parte do projeto não utiliza EntityFrameworkCore. O banco deve ser criado manualmente via script.
O script de criação do banco encontra-se no caminho ProjetoTeste.Dados, pasta SQL\SCRIPTS.
Com o banco criado, execute também as procedures existentes no mesmo projeto, na pasta SQL\PROCS.
Caso você não tenha criado a base no localDB usado pelo VisualStudio, vá no arquivo ProjetoTeste.Console, arquivo App.config e atualize os dados da connection string com seus dados de banco.
Outra configuração necessária é o endereço do WebAPI. Para alterá-lo, vá no projeto ProjetoTeste.Console, arquivo App.config e altere o link na tag appSettings\add onde `key="UrlWebService"`.
