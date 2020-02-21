using Senai.Peoples.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionariosRepository
    {
        List<FuncionariosDomain> Listar();

        void Cadastrar(FuncionariosDomain funcionarios);

        FuncionariosDomain GetById(int id);

        void Deletar(int id);

        void Atualizar(int id, FuncionariosDomain funcionarios);
    }
}
