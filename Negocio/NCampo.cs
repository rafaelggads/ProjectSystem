using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Entidade;

namespace Negocio
{
    public class NCampo
    {
        PCampo persistencia = null;

        public NCampo() 
        {
            persistencia = new PCampo();
        }
        public void Salvar(ECampo parametro)
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
        public ECampo Consultar(int identificador)
        {
            return persistencia.Consultar(identificador);
        }
        public List<ECampo> Listar(ECampo parametro)
        {
            return persistencia.Listar(parametro);
        }
        public List<ECampo> MontarCombo() {
            return persistencia.MontaCombo();
        }
    }
}
