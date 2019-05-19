using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
    public class EEquipamento:EBase
    {
         /* @Autor:RafaelGG
         */

        //Atributos
        public String referencia { get; set; }
        public String descricao { get; set; }
        public int qtdEstoque { get; set; }
        public String grupo { get; set; }
        public DateTime dataDeFabricacao { get; set; }
        public DateTime ultimaDataRevisao { get; set; }
        public int tempoDeManutencao { get; set; }

    }
}
