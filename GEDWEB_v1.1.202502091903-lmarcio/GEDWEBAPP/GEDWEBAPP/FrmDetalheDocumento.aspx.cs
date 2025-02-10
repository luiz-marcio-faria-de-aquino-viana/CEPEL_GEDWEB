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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEDWEBAPP
{

    public partial class FrmDetalheDocumento : System.Web.UI.Page
    {
    //Private
        private string m_appTitle;
        private string m_appErro;

        private int m_documentoId = 21000001;
        private int m_autorId = 1100001;
        private int m_usuarioId = 1100002;

        private DocumentoRevisaoRecord m_oUltimoDocumentoRevisao = null;
        private DocumentoRecord m_oDocumento = null;
        private UsuarioRecord m_oAutor = null;
        private UsuarioRecord m_oUsuario = null;

        private List<DocumentoRevisaoRecord> m_lsDocumentoRevisao = new List<DocumentoRevisaoRecord>();

        private void loadDocumentoMetadados()
        {
            AppMain app = AppMain.getApp();

            AppCtx ctx = app.getCtx();

            AppDatabase db = app.getDatabase();

            m_oAutor = db.findUsuarioByPk(m_autorId);
            m_oUsuario = db.findUsuarioByPk(m_usuarioId);
            m_oDocumento = db.findDocumentoByPk(m_documentoId);

            m_lsDocumentoRevisao = db.findAllDocumentoRevisaoByDocumentoId(m_documentoId);
            int sz = m_lsDocumentoRevisao.Count;
            if (sz > 0)
                m_oUltimoDocumentoRevisao = m_lsDocumentoRevisao[sz - 1];
        }

        //Public

        protected void Page_Load(object sender, EventArgs e)
        {
            initFrm();
        }

        /* Methodes */

        public void initFrm()
        {
            this.m_appTitle = AppDefs.APP_NAME + " " + AppDefs.APP_VERSAO;

            loadDocumentoMetadados();
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

        public DocumentoRevisaoRecord UltimoDocumentoRevisao
        {
            get { return m_oUltimoDocumentoRevisao; }
        }

        public List<DocumentoRevisaoRecord> LsDocumentoRevisao
        {
            get { return m_lsDocumentoRevisao; }
        }

    }

}
