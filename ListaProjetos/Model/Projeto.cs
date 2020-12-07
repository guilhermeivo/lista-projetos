using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaProjetos.Model
{
    public class Projeto
    {
        private int codProjeto;
        private int codStatus;
        private int codTag;
        private String titulo;
        private String descricao;

        public Projeto()
        {
            codProjeto = 0;
            codStatus = 0;
            codTag = 0;
            titulo = "";
            descricao = "";
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

        // codStatus methods
        public void setCodStatus(int codStatus)
        {
            this.codStatus = codStatus;
        }
        public int getCodStatus()
        {
            return codStatus;
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

        // titulo methods
        public void setTitulo(String titulo)
        {
            this.titulo = titulo;
        }
        public String getTitulo()
        {
            return titulo;
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