using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Exercicio01
{
    public class Areas
    {
        public int Codigo { get; set; }

        public decimal TamanhoArea { get; set; }

        public static int Id;

        public Areas(decimal _tamanhoArea)
        {
            TamanhoArea = _tamanhoArea;
            Codigo = Interlocked.Increment(ref Id);
        }
     
    }
}
