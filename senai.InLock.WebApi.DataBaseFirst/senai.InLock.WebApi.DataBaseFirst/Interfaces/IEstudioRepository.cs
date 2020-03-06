using senai.InLock.WebApi.DataBaseFirst.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.InLock.WebApi.DataBaseFirst.Interfaces
{
    interface IEstudioRepository
    {
        List<Estudio> Listar();

        void Cadastrar(Estudio novoEstudio);

        Estudio BuscarPorId(int id);

        void Deletar(int id);

        void Atualizar(int id, Estudio putEstudio);
    }
}
