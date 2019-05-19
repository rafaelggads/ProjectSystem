using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistencia;
using Entidade;

namespace Negocio
{
    public class NTipoUsuario
    {
            PTipoUsuario persistencia;

            public NTipoUsuario()
            {
                persistencia = new PTipoUsuario();
            }

            public ETipoUsuario Consultar(int identificador)
            {
                return persistencia.Consultar(identificador);
            }

            public List<ETipoUsuario> Listar()
            {
                return persistencia.Listar();
            }
        }
    }

