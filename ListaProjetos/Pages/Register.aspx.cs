using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListaProjetos
{
    public partial class Register : System.Web.UI.Page
    {
        static SqlConnection conn = null;
        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            String nome = txtNome.Text.Trim();
            String email = txtEmail.Text.Trim();
            String password = txtPassword.Text.Trim();

            if (nome != null && email != null && password != null)
            {
                String queryString = "insert into tblUsuario (nome, email, senha) values (@nome, @email, @senha)";
                SqlCommand cmd = new SqlCommand(queryString);

                cmd.Parameters.Add("@nome", SqlDbType.NVarChar, 70).Value = nome;
                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 70).Value = email;
                cmd.Parameters.Add("@senha", SqlDbType.Int).Value = int.Parse(password);

                int flag = DataBaseConnection.manutencaoDB(cmd);

                if (flag > 0)
                {
                    Utils.WindowAlertJavaScript("Cadastrado Com sucesso!", Page);
                }
                else
                {
                    Utils.WindowAlertJavaScript("Erro ao cadastrar!", Page);
                }
            }
            else
            {
                Utils.WindowAlertJavaScript("Insira os valores!", Page);
            }
            
        }
    }
}