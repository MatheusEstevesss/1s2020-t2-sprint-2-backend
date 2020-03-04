using senai.InLock.WebApi.DataBaseFirst.Domains;
using senai.InLock.WebApi.DataBaseFirst.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.InLock.WebApi.DataBaseFirst.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        public List<Estudio> Listar()
        {
            return ctx.Estudio.ToList();
        }
    }
}
