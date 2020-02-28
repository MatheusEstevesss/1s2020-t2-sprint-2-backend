using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuarioDomain> Listar();

        TipoUsuarioDomain GetById(int id);

        void Atualizar(int id, TipoUsuarioDomain tipoUsuario);
    }
}