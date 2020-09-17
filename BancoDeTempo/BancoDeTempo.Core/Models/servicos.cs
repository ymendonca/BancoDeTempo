using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BancoDeTempo.Core.Models
{
   public class Servicos
    {
        public string Id { get; set; }

        //[StringLength(40)]
        [DisplayName ("Titulo Experiencia")]
        public string titulo { get; set; }
        public string Descrisao { get; set; }
        public string Imagem { get; set; }
        public string Duracao { get; set; }
        public string Linguagem_partilha { get; set; }
        public string Experiencia_assunto { get; set; }
        public string Disponibilidade_partilha { get; set; }
        public string Condicao_acesso { get; set; }
        public string  Category { get; set; }


        public Servicos()
        {
            this.Id = Guid.NewGuid().ToString();
        }
        

    }
}
