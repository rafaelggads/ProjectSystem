using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entidade
{
   public class EPessoa: EBase
    {
       public EPessoa()
        {
            TipoUsuario = new ETipoUsuario();
        } 

        public string nome { get; set; }
        public string sobrenome { get; set; }
        public string email { get; set; }
        public DateTime dataDeNascimento { get; set; }
        public string telefone { get; set; }
        public string login { get; set; }
        public string senha { get; set; }
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string bairro { get; set; }
        public string cidade { get; set; }
       
        public ETipoUsuario TipoUsuario { get; set; }

    }
}
