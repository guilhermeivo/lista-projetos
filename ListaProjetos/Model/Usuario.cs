using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListaProjetos.Model
{
    public class Usuario
    {
        private int codUsuario;
        private String nome;
        private String username;
        private String email;
        private String senha;
        private String image;
        private String linkWebsite;
        private String localizacao;

        public Usuario()
        {
            codUsuario = 0;
            nome = "";
            username = "";
            email = "";
            senha = "";
            image = "";
            linkWebsite = "";
            localizacao = "";
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

        // nome methods
        public void setNome(String nome)
        {
            this.nome = nome;
        }
        public String getNome()
        {
            return nome;
        }

        // username methods
        public void setUsername(String username)
        {
            this.username = username;
        }
        public String getUsername()
        {
            return username;
        }

        // email methods
        public void setEmail(String email)
        {
            this.email = email;
        }
        public String getEmail()
        {
            return email;
        }

        // senha methods
        public void setSenha(String senha)
        {
            this.senha = senha;
        }
        public String getSenha()
        {
            return senha;
        }

        // image methods
        public void setImage(String image)
        {
            this.image = image;
        }
        public String getImage()
        {
            return image;
        }

        // linkWebsite methods
        public void setLinkWebsite(String linkWebsite)
        {
            this.linkWebsite = linkWebsite;
        }
        public String getLinkWebsite()
        {
            return linkWebsite;
        }

        // localizacao methods
        public void setLocalizacao(String localizacao)
        {
            this.localizacao = localizacao;
        }
        public String getLocalizacao()
        {
            return localizacao;
        }
    }
}