/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* AppUserAuth.cs
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

using GEDWEBAPP.Apps.Record;
using GEDWEBAPP.Apps.VO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEDWEBAPP.Apps.Base
{
    
    public class AppUserAuth
    {
    //Private Static
        private static Hashtable tblSessao = new Hashtable();

    //Public

        public static SessaoVO createSession(string login, string senha)
        {
            AppMain app = AppMain.getApp();

            AppCtx ctx = app.getCtx();

            AppDatabase db = app.getDatabase();
            UsuarioRecord oUsuario = db.findUsuarioByLogin(login);
            if (oUsuario != null) {
                if (senha.CompareTo(oUsuario.Senha) == 0) {
                    SessaoVO oSessao = new SessaoVO(oUsuario);
                    AppUserAuth.tblSessao.Add(oSessao.SessaoId, oSessao);
                    return oSessao;
                }
            }
            return null;
        }

        public static int validateSession(SessaoVO oSessao)
        {
            int sessionId = oSessao.SessaoId;
            if (AppUserAuth.tblSessao.ContainsKey(sessionId)) {
                return AppDefs.RSOK;
            }
            return AppDefs.RSERR;
        }

    }

}
