using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaProjetos.Model
{
    public class ProjetoUsuario
    {
        private int codProjeto;
        private int codUsuario;

        public ProjetoUsuario()
        {
            codProjeto = 0;
            codUsuario = 0;
        }

        // codProjeto methods
        public void setCodProjeto(int codProjeto)
        {
            this.codProjeto = codProjeto;
        }
        public int getCodProjeto()
        {
            return codProjeto;
        }

        // codUsuario methods
        public void setCodUsuario(int codUsuario)
        {
            this.codUsuario = codUsuario;
        }
        public int getCodUsuario()
        {
            return codUsuario;
        }
    }
}