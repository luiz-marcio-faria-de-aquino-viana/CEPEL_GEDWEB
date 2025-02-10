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
        private string appTitle;
        private string appErro;

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
            this.appTitle = AppDefs.APP_NAME + " " + AppDefs.APP_VERSAO;
        }

        /* Getters/Setters */

        public string AppTitle
        {
            get { return appTitle; }
            set { appTitle = value; }
        }

        public string AppErro
        {
            get { return appErro; }
            set { appErro = value; }
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
