USE M_Peoples;

INSERT INTO Funcionarios(Nome,Sobrenome)
VALUES	('Catarina','Strada')
		,('Tadeu','Vitelli');

INSERT INTO TipoUsuarios (Titulo)
VALUES	('Administrador')
		,('Comum');

INSERT INTO Usuarios (Email,Senha,IdTipoUsuario)
VALUES	('adm@adm.com','123',1)
		,('comum@comum.com','123',2);