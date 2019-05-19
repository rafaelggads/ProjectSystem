using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using Persistencia;

namespace Negocio
{
    public class NPessoa
    {
        PPessoa persistencia = null;

        public NPessoa() 
        {
            persistencia = new PPessoa();
        }
        public void Salvar(EPessoa parametro)
        {
            if(parametro.Identificador == 0)
                persistencia.Incluir(parametro);
            else
                persistencia.Alterar(parametro);        
        }
        public void Excluir(int identificador)
        {
            persistencia.Excluir(identificador);
        }
        public EPessoa Consultar(int identificador)
        {
            return persistencia.Consultar(identificador);
        }
        public List<EPessoa> ListarFiltro()
        {
            return persistencia.ListarFiltro();
        }
        public List<EPessoa> Listar(EPessoa parametro)
        {
            return persistencia.Listar(parametro);
        }
        private static int calculaIdade(DateTime dtNascimento)
        {
            int idade = DateTime.Now.Year - dtNascimento.Year;

            if (DateTime.Now.Month < dtNascimento.Month
                || (DateTime.Now.Month == dtNascimento.Month
                && DateTime.Now.Day < dtNascimento.Day))
                idade--;

            return idade;
        }

        public List<EPessoa> MontaCombo() {
            return persistencia.MontaCombo();
        }

    }
}
