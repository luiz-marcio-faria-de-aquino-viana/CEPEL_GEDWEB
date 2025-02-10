/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* ConsultaDocumento.aspx.cs
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
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GEDWEBAPP
{
    public partial class ConsultaDocumento : System.Web.UI.Page
    {
        //Private
        private string m_appTitle;
        private string m_appErro;

        private SessaoVO m_sessao;

        private List<DocumentoRecord> m_lsDocumento = new List<DocumentoRecord>();

        private void loadLsDocumento()
        {
            AppMain app = AppMain.getApp();

            AppCtx ctx = app.getCtx();

            AppDatabase db = app.getDatabase();
            m_lsDocumento = db.findAllDocumento();
        }

        //Public

        protected void Page_Load(object sender, EventArgs e)
        {
            initFrm();
        }

        /* Methodes */

        public void initFrm()
        {
            this.checkSession();
            this.loadVars();
            if (validateFrm()) {
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
        }

        public bool validateFrm()
        {
            //string errmsg = "";

            //CAMPOS_OBRIGATORIOS
            //
            //if (this.txtLogin == "")
            //    errmsg += "Login;";

            //if (this.txtSenha == "")
            //    errmsg += "Senha;";

            //if (errmsg != "")
            //{
            //    this.m_appErro = "Campos obrigatorios nao informados: " + errmsg;
            //    return false;
            //}

            return true;
        }

        public void executeFrm()
        {
            loadLsDocumento();
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

        public List<DocumentoRecord> LsDocumento
        {
            get { return m_lsDocumento; }
        }

    }

}
