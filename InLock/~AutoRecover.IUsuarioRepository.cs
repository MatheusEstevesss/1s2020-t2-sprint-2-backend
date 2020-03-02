using InLock.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InLock.Interfaces
{
    interface IUsuarioRepository 
    {
        List<UsuarioDomain> Listar();

        void Cadastrar(UsuarioDomain cadastrarUsuario);

        UsuarioDomain BuscarEmailSenha(string email, string senha);
    }
}