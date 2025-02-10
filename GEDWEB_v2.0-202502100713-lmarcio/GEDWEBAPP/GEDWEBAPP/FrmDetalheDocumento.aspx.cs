/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* FrmDetalheDocumento.aspx.cs
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

    public partial class FrmDetalheDocumento : System.Web.UI.Page
    {
    //Private
        private string m_appTitle;
        private string m_appErro;

        private SessaoVO m_sessao;

        private string m_txtTmpDocumentoId;
        private string m_txtTmpDocumentoNome;
        private string m_txtTmpDocumentoNomeArquivo;
        private string m_txtTmpDocumentoDescricao;
        private string m_txtTmpDocumentoData;
        //
        private HttpPostedFile m_file;
        //
        private string m_btnAlterar;

        private int m_documentoRevisaoId = AppDefs.NULL_INT;
        private int m_documentoId = AppDefs.NULL_INT;
        private int m_autorId = AppDefs.NULL_INT;
        private int m_usuarioId = AppDefs.NULL_INT;

        private DocumentoRevisaoRecord m_oDocumentoRevisao = null;
        private DocumentoRecord m_oDocumento = null;
        private UsuarioRecord m_oAutor = null;
        private UsuarioRecord m_oUsuario = null;

        private List<DocumentoRevisaoRecord> m_lsDocumentoRevisao = new List<DocumentoRevisaoRecord>();

        private void updateDocumentoMetadados()
        {
            AppMain app = AppMain.getApp();

            AppCtx ctx = app.getCtx();

            AppDatabase db = app.getDatabase();

            DateTime dataHoraAtual = DateTime.Now;

            this.m_txtTmpDocumentoId = Request.Params["txtTmpDocumentoId"];

            this.m_documentoId = int.Parse(this.m_txtTmpDocumentoId);
            db.updateDocumento(
                this.m_documentoId,
                this.m_txtTmpDocumentoNome,
                this.m_txtTmpDocumentoNomeArquivo,
                this.m_txtTmpDocumentoDescricao,
                this.m_txtTmpDocumentoData);

            if (this.m_file != null)
            {
                m_lsDocumentoRevisao = db.findAllDocumentoRevisaoByDocumentoId(m_documentoId);
                int sz = m_lsDocumentoRevisao.Count;

                int numeroRevisao = sz;
                string documentoRevisaoNomeDisco = string.Format("{0}-GEDWEB-{1:yyyyMMddHHmmss}.dat", m_documentoId, dataHoraAtual);
                string documentoRevisaoData = string.Format("{0:yyyy-MM-dd_HHmm}", dataHoraAtual);

                string fileName = m_file.FileName;

                string ff = ctx.RepositorioDir + documentoRevisaoNomeDisco;
                m_file.SaveAs(ff);

                db.insertDocumentoRevisao(
                    m_documentoId,
                    numeroRevisao,
                    documentoRevisaoNomeDisco,
                    documentoRevisaoData);
            }

            m_oDocumento = db.findDocumentoByPk(m_documentoId);
            if (m_oDocumento != null)
            {
                m_autorId = m_oDocumento.AutorId;
                m_oAutor = db.findUsuarioByPk(m_autorId);

                m_usuarioId = m_sessao.UsuarioId;
                m_oUsuario = db.findUsuarioByPk(m_usuarioId);

                m_lsDocumentoRevisao = db.findAllDocumentoRevisaoByDocumentoId(m_documentoId);
                int sz = m_lsDocumentoRevisao.Count;
                if (sz > 0)
                    m_oDocumentoRevisao = m_lsDocumentoRevisao[sz - 1];
            }
        }

        private void loadDocumentoMetadados()
        {
            AppMain app = AppMain.getApp();

            AppCtx ctx = app.getCtx();

            AppDatabase db = app.getDatabase();

            m_oDocumentoRevisao = db.findDocumentoRevisaoByPk(m_documentoRevisaoId);
            if (m_oDocumentoRevisao != null)
            {
                m_documentoId = m_oDocumentoRevisao.DocumentoId;
                m_oDocumento = db.findDocumentoByPk(m_documentoId);
                if (m_oDocumento != null)
                {
                    m_autorId = m_oDocumento.AutorId;
                    m_oAutor = db.findUsuarioByPk(m_autorId);

                    m_usuarioId = m_sessao.UsuarioId;
                    m_oUsuario = db.findUsuarioByPk(m_usuarioId);

                    m_lsDocumentoRevisao = db.findAllDocumentoRevisaoByDocumentoId(m_documentoId);
                }
            }
            else
            {
                m_oDocumento = db.findDocumentoByPk(m_documentoId);
                if (m_oDocumento != null)
                {
                    m_autorId = m_oDocumento.AutorId;
                    m_oAutor = db.findUsuarioByPk(m_autorId);

                    m_usuarioId = m_sessao.UsuarioId;
                    m_oUsuario = db.findUsuarioByPk(m_usuarioId);

                    m_lsDocumentoRevisao = db.findAllDocumentoRevisaoByDocumentoId(m_documentoId);
                    int sz = m_lsDocumentoRevisao.Count;
                    if (sz > 0)
                        m_oDocumentoRevisao = m_lsDocumentoRevisao[sz - 1];
                }
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
            if (m_sessao == null) {
                Response.Redirect("FrmLogin.aspx", true);
            }
            else {
                int rscode = AppUserAuth.validateSession(m_sessao);
                if (rscode == AppDefs.RSERR) {
                    Response.Redirect("FrmLogin.aspx", true);
                }
            }
        }

        public void loadVars()
        {
            this.m_appTitle = AppDefs.APP_NAME + " " + AppDefs.APP_VERSAO;

            this.m_btnAlterar = Request.Params["btnAlterar"];
            if (this.m_btnAlterar == null)
            {
                string strDocumentoRevisaoId = Request.QueryString["DocumentoRevisaoId"];
                if(strDocumentoRevisaoId != null)
                    this.m_documentoRevisaoId = int.Parse(strDocumentoRevisaoId);

                string strDocumentoId = Request.QueryString["DocumentoId"];
                if (strDocumentoId != null)
                    this.m_documentoId = int.Parse(strDocumentoId);
            }
            else {
                this.m_txtTmpDocumentoId = Request.Params["txtTmpDocumentoId"];
                this.m_txtTmpDocumentoNome = Request.Params["txtTmpDocumentoNome"];
                this.m_txtTmpDocumentoNomeArquivo = Request.Params["txtTmpDocumentoNomeArquivo"];
                this.m_txtTmpDocumentoDescricao = Request.Params["txtTmpDocumentoDescricao"];
                this.m_txtTmpDocumentoData = Request.Params["txtTmpDocumentoData"];

                this.m_file = Request.Files["fileNovoArquivo"];
            }
        }

        public bool validateFrm()
        {
            this.m_btnAlterar = Request.Params["btnAlterar"];
            if (this.m_btnAlterar == null) return true;

            string errmsg = "";

            //CAMPOS_OBRIGATORIOS
            //
            if (this.m_txtTmpDocumentoNome == "")
                errmsg += "DocumentoNome;";

            if (this.m_txtTmpDocumentoNomeArquivo == "")
                errmsg += "DocumentoNomeArquivo;";

            if (this.m_txtTmpDocumentoDescricao == "")
                errmsg += "DocumentoDescricao;";

            if (this.m_txtTmpDocumentoData == "")
                errmsg += "DocumentoData;";

            if (errmsg != "")
            {
                this.m_appErro = "Campos obrigatorios nao informados: " + errmsg;
                return false;
            }

            return true;
        }

        public void executeFrm()
        {
            if (this.m_btnAlterar == null)
                loadDocumentoMetadados();
            else
                updateDocumentoMetadados();
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

        public int UsuarioId
        {
            get { return m_usuarioId; }
        }

        public int DocumentoId
        {
            get { return m_documentoId; }
        }

        public int AutorId
        {
            get { return m_autorId; }
        }

        public UsuarioRecord Usuario
        {
            get { return m_oUsuario; }
        }

        public UsuarioRecord Autor
        {
            get { return m_oAutor; }
        }

        public DocumentoRecord Documento
        {
            get { return m_oDocumento; }
        }

        public DocumentoRevisaoRecord DocumentoRevisao
        {
            get { return m_oDocumentoRevisao; }
        }

        public List<DocumentoRevisaoRecord> LsDocumentoRevisao
        {
            get { return m_lsDocumentoRevisao; }
        }

        public string TmpDocumentoId
        {
            get { return m_txtTmpDocumentoId; }
        }

        public string TmpDocumentoNome
        {
            get { return m_txtTmpDocumentoNome; }
        }

        public string TmpDocumentoNomeArquivo
        {
            get { return m_txtTmpDocumentoNomeArquivo; }
        }

        public string TmpDocumentoDescricao
        {
            get { return m_txtTmpDocumentoDescricao; }
        }

        public string TmpDocumentoData
        {
            get { return m_txtTmpDocumentoData; }
        }

        public string BtnAlterar
        {
            get { return m_btnAlterar; }
        }

    }

}
