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
    }
}
