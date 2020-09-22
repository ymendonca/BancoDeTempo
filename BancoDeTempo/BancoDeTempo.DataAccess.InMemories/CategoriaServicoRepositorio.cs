using BancoDeTempo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeTempo.DataAccess.InMemories
{
   public class CategoriaServicoRepositorio
    {
        ObjectCache cache = MemoryCache.Default;
        List<CategoriaServico> servicoscategories;

        public CategoriaServicoRepositorio()
        {
            servicoscategories = cache["servicoscategories"] as List<CategoriaServico>;
            if (servicoscategories == null)
            {
                servicoscategories = new List<CategoriaServico>();
            }
        }

        public void Commit()
        {
            cache["servicoscategories"] = servicoscategories;
        }

        public void Insert(CategoriaServico s)
        {
            servicoscategories.Add(s);
        }

        public void Update(CategoriaServico servicocategory)
        {
            CategoriaServico servicoscategoriesToUpdate = servicoscategories.Find(s => s.Id == servicocategory.Id);

            if (servicoscategoriesToUpdate != null)
            {
                servicoscategoriesToUpdate = servicocategory;
            }
            else
            {
                throw new Exception("Servicos nao encontrado");
            }
        }

        public CategoriaServico Find(string Id)
        {
            CategoriaServico servicocategory = servicoscategories.Find(s => s.Id == Id);

            if (servicocategory != null)
            {
                return servicocategory;
            }
            else
            {
                throw new Exception("Servicos nao encontrado");
            }
        }

        public IQueryable<CategoriaServico> Collection()
        {
            return servicoscategories.AsQueryable();
        }

        public void Delete(string Id)
        {
            CategoriaServico servicoscategoriesToDelete = servicoscategories.Find(s => s.Id == Id);

            if (servicoscategoriesToDelete != null)
            {
                servicoscategories.Remove(servicoscategoriesToDelete);
            }
            else
            {
                throw new Exception("Servicos nao encontrado");
            }
        }
    }
}
