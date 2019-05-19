using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    public class ETipoUsuario: EBase
    {
        public string Descricao { get; set; }
        public enum Tipo1 { Administrador = 1};
        public enum Tipo2 { Cliente = 2 };
    }
}
