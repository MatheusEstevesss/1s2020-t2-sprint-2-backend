USE M_Peoples;

select * from Funcionarios;

select * from TipoUsuarios;

SELECT Usuarios.IdUsuario,Usuarios.Email, Usuarios.Senha, TipoUsuarios.Titulo FROM Usuarios 
INNER JOIN TipoUsuarios ON Usuarios.IdTipoUsuario = TipoUsuarios.IdTipoUsuario;