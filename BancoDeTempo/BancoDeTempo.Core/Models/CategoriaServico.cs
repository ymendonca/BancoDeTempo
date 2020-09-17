using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeTempo.Core.Models
{
   public class CategoriaServico
    {
        public string Id { get; set; }
        public string Category { get; set; }

        public CategoriaServico()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
