using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IUsuariosRepository
    {
        List<UsuarioDomain> Listar();

        void Cadastrar(UsuarioDomain usuarios);

        UsuarioDomain GetById(int id);

        void Deletar(int id);

        void Atualizar(int id, UsuarioDomain usuarios);
    }
}
