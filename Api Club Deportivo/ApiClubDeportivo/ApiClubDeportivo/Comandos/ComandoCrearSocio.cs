using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClubDeportivo.Comandos
{
    public class ComandoCrearSocio
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Calle { get; set; }
        public int Numero { get; set; }
        public int IdDeporte { get; set; }

    }
}
