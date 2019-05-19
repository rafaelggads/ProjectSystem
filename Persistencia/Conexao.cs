using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Persistencia
{
    public static class Conexao
    {
        public static string Caminho
        {
            get
            {
                AppSettingsReader reader = new AppSettingsReader();
                return reader.GetValue("ConexaoBanco", typeof(string)).ToString();
            }
        }
    }
}

