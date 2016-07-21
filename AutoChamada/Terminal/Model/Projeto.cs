using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    public class Projeto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int DiaDaSemana { get; set; } //0-SEGUNDA, 1-TERÇA...
        public int Turno { get; set; }
        public int IdProfessor { get; set; }
    }
}
