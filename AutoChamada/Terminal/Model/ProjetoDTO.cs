using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    public class ProjetoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DiaDaSemana { get; set; } //0-SEGUNDA, 1-TERÇA...
        public string Turno { get; set; }
    }
}
