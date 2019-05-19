using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    public class EReserva:EBase
    {
        /* @Autor:RafaelGG
        */
        public EReserva() {
            FCodCampo = new ECampo();
            FCodCliente = new EPessoa();
        }
        //Atributos
        public DateTime data { get; set; }
        public DateTime dataDaReserva { get; set; }
        public EPessoa FCodCliente { get; set; }
        public ECampo FCodCampo { get; set; }
        public double qtdDeHoras { get; set; }
        public decimal valorTotal { get; set; }
        public decimal valorHora { get; set; }
        
    }
}
