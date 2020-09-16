using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using BancoDeTempo.Core.Models;

namespace BancoDeTempo.DataAccess.InMemories
{
    public class ServicosRepositorio
    {
        ObjectCache cache = MemoryCache.Default;
        List<Servicos> servicos;

        public ServicosRepositorio()
        {
            servicos = cache["servicos"] as List<Servicos>;
            if(servicos == null)
            {
                servicos = new List<Servicos>();
            }
        }

        public void Commit()
        {
            cache["servicos"] = servicos; 
        }

        public void Insert(Servicos s)
        {
            servicos.Add(s);
        }

        public void Update(Servicos servico)
        {
            Servicos servicoToUpdate = servicos.Find(s => s.Id == servico.Id);

            if(servicoToUpdate != null) {
                servicoToUpdate = servico;
            }
            else
            {
                throw new Exception("Servicos nao encontrado");
            }
        }

        public Servicos Find(string Id)
        {
            Servicos servico = servicos.Find(s => s.Id == Id);

            if (servico != null)
            {
                return servico;
            }
            else
            {
                throw new Exception("Servicos nao encontrado");
            }
        }

        public IQueryable<Servicos> Collection()
        {
            return servicos.AsQueryable();
        }

        public void Delete(string Id)
        {
            Servicos servicoToDelete = servicos.Find(s => s.Id == Id);

            if (servicoToDelete != null)
            {
                servicos.Remove(servicoToDelete);
            }
            else
            {
                throw new Exception("Servicos nao encontrado");
            }
        }

    }
}
