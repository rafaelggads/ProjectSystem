using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Entidade;

namespace Negocio
{
    public class NReserva
    {
        PReserva persistencia = null;

        public NReserva() 
        {
            persistencia = new PReserva();
        }
        public void Salvar(EReserva parametro)
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
        public EReserva Consultar(int identificador)
        {
            return persistencia.Consultar(identificador);
        }
        public List<EReserva> Listar(EReserva parametro)
        {
            return persistencia.Listar(parametro);
        }
    }
}