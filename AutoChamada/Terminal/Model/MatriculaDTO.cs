using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terminal
{
    public class MatriculaDTO
    {
        public Aluno aluno { get; set; }
        public AlunoProjeto projetoMatutino { get; set; }
        //SEGUNDA
        public AlunoProjeto projetoD0T2 { get; set; } //TURNO A
        public AlunoProjeto projetoD0T3 { get; set; } //TURNO B
        //TERÇA
        public AlunoProjeto projetoD1T2 { get; set; } //TURNO A
        public AlunoProjeto projetoD1T3 { get; set; } //TURNO B
        //QUARTA
        public AlunoProjeto projetoD2T2 { get; set; } //TURNO A
        public AlunoProjeto projetoD2T3 { get; set; } //TURNO B
        //QUINTA
        public AlunoProjeto projetoD3T2 { get; set; } //TURNO A
        public AlunoProjeto projetoD3T3 { get; set; } //TURNO B
        //SEXTA
        public AlunoProjeto projetoD4T2 { get; set; } //TURNO A
        public AlunoProjeto projetoD4T3 { get; set; } //TURNO B
    }
}
