using Microsoft.EntityFrameworkCore;
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
        private IEstudioRepository estudioRepository;

        InLockContext ctx = new InLockContext();

        public List<Estudio> Listar()
        {
            return ctx.Estudio.ToList();
        }
        public Estudio BuscarPorId(int id)
        {
            // Retorna o primeiro estúdio encontrado para o ID informado
            return ctx.Estudio.FirstOrDefault(e => e.IdEstudio == id);
        }

        public void Cadastrar(Estudio novoEstudio)
        {
            // Adiciona este novoEstudio
            ctx.Estudio.Add(novoEstudio);
            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        public void Deletar(int id)
        {
            IQueryable<Estudio> IdBuscado = ctx.Estudio.Where(e => e.IdEstudio == id);

            ctx.Estudio.Remove(IdBuscado);

            ctx.SaveChanges();

        }

        public void Atualizar(int id, Estudio putEstudio)
        {
            ctx.Estudio.Update();

            ctx.SaveChanges();
        }
    }
}
