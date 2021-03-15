# SistemaDeProdutos

Um sistema webpara fazer o gerenciamento de produtos, podendo cadastrar, consultar, alterar e deletar produtos.
A persistência de dados foi feita utilizando o banco de dados SQL Server.

O Frontend foi desenvolvido uma SPA com Angular, sendo uma só página para todo o gerenciamento. 
Os produtos registrados são mostrados em uma tabela com todos os dados do produto e uma coluna com opções de editar e excluir.
A tablea possui um sistema de paginação com tamanho de 10 registros em cada página. Também possui um sistema de filtro.
O botão para criar ou editar um produto, abre uma modal para inserir as informações.

O Backend foi desenvolvido uma API em Asp.Net Core com o Entity Framework. O Frontend faz requsições das APIs para consultar, fazer novos registros e editar os produtos.
