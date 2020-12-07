using ListaProjetos.Controllers;
using ListaProjetos.Model;
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
                Projeto projeto = new Projeto();
                projeto.setTitulo(txtTitulo.Text.Trim());
                projeto.setDescricao(txtDescricao.Text.Trim());

                Tag tag = new Tag();
                tag.setCodTag(0);
                tag.setDescricao(txtTags.Text.Trim());

                _Status _status = new _Status();
                _status.setCodStatus(int.Parse(ddlStatus.SelectedValue));
                _status.setDescricao(ddlStatus.Text);

                if (projeto.getTitulo() != "" && projeto.getDescricao() != "" && tag.getDescricao() != "")
                {
                    Tag tagReturn = TagController.listarTag(this, tag.getDescricao());

                    if (tagReturn != null)
                    {
                        tag.setCodTag(tagReturn.getCodTag());
                        tag.setDescricao(tagReturn.getDescricao());
                    }
                    else
                    {
                        tag.setDescricao(tag.getDescricao().Replace(" ", "").Trim());

                        TagController.criarTag(this, tag);

                        tagReturn = TagController.listarTag(this, tag.getDescricao());

                        if (tagReturn != null)
                        {
                            tag.setCodTag(tagReturn.getCodTag());
                        }
                    }

                    projeto.setCodStatus(_status.getCodStatus());
                    projeto.setCodTag(tag.getCodTag());

                    ProjetoController.criarProjeto(this, projeto);

                    int final = ProjetoController.finalProjeto(this);

                    if (final >= 0)
                    {
                        ProjetoUsuario projetoUsuario = new ProjetoUsuario();
                        projetoUsuario.setCodProjeto(final);
                        projetoUsuario.setCodUsuario(int.Parse(Request.Cookies["codUsuario"].Value));

                        ProjetoUsuarioController.criarProjetoUsuario(this, projetoUsuario);

                        Response.Redirect("~/Views/ListProjects.aspx");
                    }
                    else
                    {
                        Utils.ShowMessage(this, "Error!");
                    }                    
                }
                else
                {
                    Utils.ShowMessage(this, "Insira os valores!");
                }
            }
            catch (Exception ex)
            {
                Utils.ShowMessage(this, "error:" + ex);
            }
        }

        public void LoadSubjects()
        {
            SqlConnection conn = Connection.open();

            String queryString = "select * from tblStatus";

            try
            {
                SqlDataAdapter adaptador = new SqlDataAdapter(queryString, conn);
                DataSet ds = new DataSet();
                adaptador.Fill(ds);

                DataTable dt = ds.Tables[0];

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
                    Utils.ShowMessage(this, "Erro ao carregar!");
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                Connection.close();
            }
        }
    }
}