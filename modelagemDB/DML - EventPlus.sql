--DML DATA MANIPULATION LANGUAGE

INSERT INTO TipoDeUsuario (TituloTipoDeUsuario)
VALUES ('Administrador'), ('Comum')

INSERT INTO TipoDeEvento (TituloTipoDeEvento)
VALUES ('SQL Server')

INSERT INTO Instituicao (NomeFantasia,CNPJ,Endereco)
VALUES ('DevSchool', '12345678901234', 'Rua Niter�i 180')

INSERT INTO Usuario (IdTipoDeUsuario, Nome, Email, Senha)
VALUES (1, 'Guilherme', 'admin@admin.admin', 'admin1234')

INSERT INTO Evento (IdTipoDeEvento, IdInstituicao, Nome, Descricao, DataEvento, HorarioEvento)
VALUES(1, 1, 'Introdu��o ao banco de dados SQL Server', 'Aprenda os conceitos b�sicos do SQL Server', '2023-08-10', '10:00:00')

INSERT INTO InscricaoEvento (IdUsuario, IdEvento)
VALUES (1,1)

INSERT INTO Comentario (IdUsuario, IdEvento, Descricao, Exibe)
VALUES (1, 1, 'Muito bom o evento, gostei muito!!!!!!!!!!!!!!!!!!!!!!', 1)