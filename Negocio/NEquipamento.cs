using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entidade;
using Persistencia;

namespace Negocio
{
    public class NEquipamento
    {
        PEquipamento persistencia = null;

        public NEquipamento() 
        {
            persistencia = new PEquipamento();
        }
        public void Salvar(EEquipamento parametro)
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
        public EEquipamento Consultar(int identificador)
        {
            return persistencia.Consultar(identificador);
        }
        public List<EEquipamento> Listar(EEquipamento parametro)
        {
            return persistencia.Listar(parametro);
        }
    }
}
