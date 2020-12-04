using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListaProjetos.Views
{
    public partial class CreateProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadSubjects();
            }
        }

        protected void btnProjeto_Click(object sender, EventArgs e)
        {
            try
            {
                String titulo = txtTitulo.Text.Trim();
                String descricao = txtDescricao.Text.Trim();
                String tag = txtTags.Text.Trim();
                int codTag;
                String status = ddlStatus.SelectedValue;

                if (titulo != null && descricao != null && tag != null)
                {
                    String queryStringTags = "select * from tblTag where '" + tag + "' = descricao";
                    DataTable dtTags = Connection.executarSQL(queryStringTags);

                    if (dtTags.Rows.Count > 0)
                    {
                        DataRow[] rowsTags = dtTags.Select();
                        codTag = int.Parse(rowsTags[0]["codTag"].ToString());

                        String queryStringProjetos = "insert into tblProjeto (codStatus, codTag, titulo, descricao) values (@codStatus, @codTag, @titulo, @descricao)";
                        SqlCommand cmdProjetos = new SqlCommand(queryStringProjetos);
                        cmdProjetos.Parameters.Add("@codStatus", SqlDbType.Int).Value = int.Parse(status);
                        cmdProjetos.Parameters.Add("@codTag", SqlDbType.Int).Value = codTag;
                        cmdProjetos.Parameters.Add("@titulo", SqlDbType.NVarChar, 70).Value = titulo;
                        cmdProjetos.Parameters.Add("@descricao", SqlDbType.NVarChar, 200).Value = descricao;

                        int flag = Connection.manutencaoDB(cmdProjetos);

                        if (flag > 0)
                        {
                            flag = 0;

                            DataTable dtlastProjeto = Connection.executarSQL("select ident_current('tblProjeto') as TOTAL");
                            DataRow[] rowsLastProjeto = dtlastProjeto.Select();

                            String queryStringProjetosUsuario = "insert into tblProjetoUsuario (codProjeto, codUsuario) values (@codProjeto, @codUsuario)";
                            SqlCommand cmdProjetosUsuario = new SqlCommand(queryStringProjetosUsuario);

                            cmdProjetosUsuario.Parameters.Add("@codProjeto", SqlDbType.Int).Value = int.Parse(rowsLastProjeto[0]["TOTAL"].ToString());
                            cmdProjetosUsuario.Parameters.Add("@codUsuario", SqlDbType.Int).Value = int.Parse(Request.Cookies["codUsuario"].Value);

                            flag = Connection.manutencaoDB(cmdProjetosUsuario);

                            if (flag > 0)
                            {
                                Utils.ShowMessage(Page, "Sucesso!");
                            }
                            else
                            {
                                Utils.ShowMessage(Page, "Erro ao cadastrar Projeto para usuario!");
                            }
                        }
                        else
                        {
                            Utils.ShowMessage(Page, "Erro ao cadastrar Projeto!");
                        }
                    }
                    else
                    {
                        Utils.ShowMessage(Page, "Tag invalida!");
                    }
                }
                else
                {
                    Utils.ShowMessage(Page, "Insira os valores!");
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(Page, "error:" + ex);
            }
        }

        public void LoadSubjects()
        {
            try
            {
                String queryString = "select * from tblStatus";

                DataTable dt = Connection.executarSQL(queryString);

                if (dt.Rows.Count > 0)
                {
                    ddlStatus.DataSource = dt;
                    ddlStatus.DataBind();
                    ddlStatus.DataTextField = "descricao";
                    ddlStatus.DataValueField = "codStatus";
                    ddlStatus.DataBind();
                }
                else
                {
                    Utils.ShowMessage(Page, "Erro ao cadastrar!");
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(Page, "Erro ao cadastrar!");
            }
        }
    }
}