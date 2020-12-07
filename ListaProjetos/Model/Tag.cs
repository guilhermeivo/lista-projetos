using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaProjetos.Model
{
    public class Tag
    {
        private int codTag;
        private String descricao;

        public Tag()
        {
            codTag = 0;
            descricao = "";
        }

        // codTag methods
        public void setCodTag(int codTag)
        {
            this.codTag = codTag;
        }
        public int getCodTag()
        {
            return codTag;
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