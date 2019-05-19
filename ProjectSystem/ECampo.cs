using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    public class ECampo : EBase
    {
        /*
         * @Autor:RafaelGG
         */

        //Atributos
       
        public String descricao { get; set; }
        public Double comprimento { get; set; }
        public Double largura { get; set; }
        public int qtdObstaculos { get; set; }
        public Decimal valorHora { get; set; }
    }
}
