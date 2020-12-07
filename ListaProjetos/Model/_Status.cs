using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaProjetos.Model
{
    public class _Status
    {
        private int codStatus;
        private String descricao;

        public _Status()
        {
            codStatus = 0;
            descricao = "";
        }

        // codStatus methods
        public void setCodStatus(int codStatus)
        {
            this.codStatus = codStatus;
        }
        public int getCodStatus()
        {
            return codStatus;
        }

        // descricao methods
        public void setDescricao(String descricao)
        {
            this.descricao = descricao;
        }
        public String getDescricao()
        {
            return descricao;
        }
    }
}