/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* FrmCadastroDocumento.aspx.cs
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

using GEDWEBAPP.Apps;
using GEDWEBAPP.Apps.Base;
using GEDWEBAPP.Apps.Record;
using GEDWEBAPP.Apps.VO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace GEDWEBAPP
{

    public partial class FrmCadastroDocumento : System.Web.UI.Page
    {
        //Private
        private string m_appTitle;
        private string m_appErro;

        private SessaoVO m_sessao;

        private string m_txtTmpDocumentoNome;
        private string m_txtTmpDocumentoNomeArquivo;
        private string m_txtTmpDocumentoDescricao;
        //
        private HttpPostedFile m_file;
        //
        private string m_btnEnviar;

        private int m_documentoRevisaoId = AppDefs.NULL_INT;
        private int m_documentoId = AppDefs.NULL_INT;
        private int m_autorId = AppDefs.NULL_INT;

        private DocumentoRevisaoRecord m_oDocumentoRevisao = null;
        private DocumentoRecord m_oDocumento = null;
        private UsuarioRecord m_oAutor = null;

        private void insertDocumentoMetadados()
        {
            AppMain app = AppMain.getApp();

            AppCtx ctx = app.getCtx();

            AppDatabase db = app.getDatabase();

            DateTime dataHoraAtual = DateTime.Now;

            string strDateHora = string.Format("{0:yyyyMMdd_HHmm}", dataHoraAtual);

            this.m_autorId = m_sessao.UsuarioId;

            this.m_documentoId = db.insertDocumento(
                this.m_txtTmpDocumentoNome,
                this.m_txtTmpDocumentoNomeArquivo,
                this.m_txtTmpDocumentoDescricao,
                strDateHora,
                this.m_autorId);

            if (this.m_file != null)
            {
                int numeroRevisao = 0;
                string documentoRevisaoNomeDisco = string.Format("{0}-GEDWEB-{1:yyyyMMddHHmmss}.dat", m_documentoId, dataHoraAtual);

                string fileName = m_file.FileName;

                string ff = ctx.RepositorioDir + documentoRevisaoNomeDisco;
                m_file.SaveAs(ff);

                db.insertDocumentoRevisao(
                    m_documentoId,
                    numeroRevisao,
                    documentoRevisaoNomeDisco,
                    strDateHora);
            }

        }

        //Public

        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.Form.Attributes.Add("enctype", "multipart/form-data");

            initFrm();
        }

        /* Methodes */

        public void initFrm()
        {
            this.checkSession();
            this.loadVars();
            if (validateFrm())
            {
                this.executeFrm();
            }
        }

        public void checkSession()
        {
            m_sessao = (SessaoVO)Session[AppDefs.DEF_SESSION_NAME];
            if (m_sessao == null)
            {
                Response.Redirect("FrmLogin.aspx", true);
            }
            else
            {
                int rscode = AppUserAuth.validateSession(m_sessao);
                if (rscode == AppDefs.RSERR)
                {
                    Response.Redirect("FrmLogin.aspx", true);
                }
            }
        }

        public void loadVars()
        {
            this.m_appTitle = AppDefs.APP_NAME + " " + AppDefs.APP_VERSAO;

            this.m_btnEnviar = Request.Params["btnEnviar"];
            if (this.m_btnEnviar != null)
            {
                this.m_txtTmpDocumentoNome = Request.Params["txtTmpDocumentoNome"];
                this.m_txtTmpDocumentoNomeArquivo = Request.Params["txtTmpDocumentoNomeArquivo"];
                this.m_txtTmpDocumentoDescricao = Request.Params["txtTmpDocumentoDescricao"];

                this.m_file = Request.Files["fileNovoArquivo"];
            }
        }

        public bool validateFrm()
        {
            this.m_btnEnviar = Request.Params["btnEnviar"];
            if (this.m_btnEnviar == null) return true;

            string errmsg = "";

            //CAMPOS_OBRIGATORIOS
            //
            if (this.m_txtTmpDocumentoNome == "")
                errmsg += "DocumentoNome;";

            if (this.m_txtTmpDocumentoNomeArquivo == "")
                errmsg += "DocumentoNomeArquivo;";

            if (this.m_txtTmpDocumentoDescricao == "")
                errmsg += "DocumentoDescricao;";

            if (errmsg != "")
            {
                this.m_appErro = "Campos obrigatorios nao informados: " + errmsg;
                return false;
            }

            return true;
        }

        public void executeFrm()
        {
            if (this.m_btnEnviar != null) {
                insertDocumentoMetadados();
            }
        }

        /* Getters/Setters */

        public string AppTitle
        {
            get { return m_appTitle; }
        }

        public string AppErro
        {
            get { return m_appErro; }
        }

        public int DocumentoId
        {
            get { return m_documentoId; }
        }

        public int AutorId
        {
            get { return m_autorId; }
        }

        public UsuarioRecord Autor
        {
            get { return m_oAutor; }
        }

        public DocumentoRecord Documento
        {
            get { return m_oDocumento; }
        }

        public string BtnEnviar
        {
            get { return m_btnEnviar; }
        }

    }

}
