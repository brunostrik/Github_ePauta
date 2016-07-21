using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;

namespace Terminal
{
    public class FotoAlunoDTO
    {
        private static MemoryStream ms;
        public int IdAluno { get; set; }
        public int IdFoto { get; set; }
        public byte[] Imagem { get; set; }
        public Image Foto
        {
            get
            {
                try
                {
                    ms = new MemoryStream(Imagem);
                    return Image.FromStream(ms);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }
    }
}
