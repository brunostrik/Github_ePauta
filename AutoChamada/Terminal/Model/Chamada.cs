using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    public class Chamada
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public int Turno { get; set; } //0-MATUTINO 1-VESP-A 2-VESP-B
        public string Obs { get; set; }
        public int CargaHoraria { get; set; }
    }
}
