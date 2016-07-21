using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    public class CalendarioDTO
    {
        public DateTime Dia { get; set; }
        public int DiaDaSemana { get; set; } //Dia da semana numérico
        public String DiaDaSemanaString
        {
            get
            {
                return Program.DiaDaSemana(DiaDaSemana);
            }
        }
        public double Matutino { get; set; }
        public double VespertinoA { get; set; }
        public double VespertinoB { get; set; }
        public double Total
        {
            get
            {
                return Matutino + VespertinoA + VespertinoB;
            }
        }
        public int idMatutino { get; set; }
        public int idVespertinoA { get; set; }
        public int idVespertinoB { get; set; }
    }
}
