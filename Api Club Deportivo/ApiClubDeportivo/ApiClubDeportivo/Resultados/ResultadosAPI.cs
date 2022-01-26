using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClubDeportivo.Resultados
{
    public class ResultadosAPI
    {
        public bool Ok { get; set; }
        public string Error { get; set; }
        public int CodigoError { get; set; }
        public string InfoAdicional { get; set; }
        public object Return { get; set; }

    }
}
