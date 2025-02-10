/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* FrmLogin.aspx.cs
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

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
    public partial class FrmLogin : System.Web.UI.Page
    {
        //Private
        private string m_appTitle;
        private string m_appErro;

        private SessaoVO m_sessao;

        private string txtLogin;
        private string txtSenha;

        //Public

        protected void Page_Load(object sender, EventArgs e)
        {
            initFrm();
        }

        /* Methodes */

        public void initFrm()
        {
            this.loadVars();

            if (validateFrm()) {
                this.executeFrm();
            }
        }

        public void loadVars()
        {
            this.m_appTitle = AppDefs.APP_NAME + " " + AppDefs.APP_VERSAO;

            this.txtLogin = Request.Params["txtLogin"];
            if (this.txtLogin == null)
                this.txtLogin = "";

            this.txtSenha = Request.Params["txtSenha"];
            if (this.txtSenha == null)
                this.txtSenha = "";
        }

        public bool validateFrm()
        {
            string errmsg = "";

            //CAMPOS_OBRIGATORIOS
            //
            if (this.txtLogin == "")
                errmsg += "Login;";

            if (this.txtSenha == "")
                errmsg += "Senha;";

            if (errmsg != "") {
                this.m_appErro = "Campos obrigatorios nao informados: " + errmsg;
                return false;
            }

            return true;
        }

        public void executeFrm()
        {
            SessaoVO oSessao = (SessaoVO)AppUserAuth.createSession(this.txtLogin, this.txtSenha);
            if (oSessao != null) {
                Session[AppDefs.DEF_SESSION_NAME] = oSessao;

                Response.Redirect("FrmConsultaDocumento.aspx", true);
            }
        }

        /* Getters/Setters */

        public string AppTitle
        {
            get { return m_appTitle; }
            set { m_appTitle = value; }
        }

        public string AppErro
        {
            get { return m_appErro; }
            set { m_appErro = value; }
        }

        public string TxtLogin
        {
            get { return txtLogin; }
            set { txtLogin = value; }
        }

        public string TxtSenha
        {
            get { return txtSenha; }
            set { txtSenha = value; }
        }

    }

}
