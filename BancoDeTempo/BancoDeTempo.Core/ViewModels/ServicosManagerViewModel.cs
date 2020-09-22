using BancoDeTempo.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeTempo.Core.ViewModels
{
    public class ServicosManagerViewModel
    {
        public Servicos Servicos { get; set; }
        public IEnumerable<CategoriaServico> Servicoscategories { get; set; }
    }
}
