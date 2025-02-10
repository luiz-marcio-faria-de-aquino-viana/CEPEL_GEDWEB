/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* UsuarioRecord.cs
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEDWEBAPP.Apps.Record
{

    public class UsuarioRecord
    {
    //Private
        private int m_usuarioId;
        private string m_nome;
        private string m_formacao;
        private string m_telefone;
        private string m_email;
        private string m_login;
        private string m_senha;

    //Public

        public UsuarioRecord()
        {
            init(
                AppDefs.NULL_INT,
                AppDefs.NULL_STR,
                AppDefs.NULL_STR,
                AppDefs.NULL_STR,
                AppDefs.NULL_STR,
                AppDefs.NULL_STR,
                AppDefs.NULL_STR);
        }

        /* Methodes */

        public void init(
            int usuarioId,
            string nome,
            string formacao,
            string telefone,
            string email,
            string login,
            string senha)
        {
            m_usuarioId = usuarioId;
            m_nome = nome;
            m_formacao = formacao;
            m_telefone = telefone;
            m_email = email;
            m_login = login;
            m_senha = senha;
        }

        /* DATA */

        public static string toDataStoreHeader()
        {
            string strOut = "UsuarioId^Nome^Formacao^Telefone^Email^Login^Senha\n";
            return strOut;
        }

        public string toDataStore()
        {
            string strOut = string.Format(
                "{0}^{1}^{2}^{3}^{4}^{5}^{6}\n",
                m_usuarioId,
                m_nome,
                m_formacao,
                m_telefone,
                m_email,
                m_login,
                m_senha);
            return strOut;
        }

        public void fromDataStore(string str)
        {
            string[] arr = str.Split('^');
            if (arr.Length >= 7) {
                m_usuarioId = int.Parse(arr[0]);
                m_nome = arr[1];
                m_formacao = arr[2];
                m_telefone = arr[3];
                m_email = arr[4];
                m_login = arr[5];
                m_senha = arr[6];
            }
        }

        /* DEBUG */

        public string toStr()
        {
            string str = string.Format(
                "UsuarioId:{0};" +
                "Nome:{1};" +
                "Formacao:{2};" +
                "Telefone:{3};" +
                "Email:{4};" +
                "Login:{5};" +
                "Senha:{6}\n",
                m_usuarioId,
                m_nome,
                m_formacao,
                m_telefone,
                m_email,
                m_login,
                m_senha);
            return str;
        }

        public void debug(int debugLevel)
        {
            if (debugLevel != AppDefs.DEBUG_LEVEL) return;

            string str = this.toStr();
            
        }

        /* Getters/Setters */

        public int UsuarioId
        {
            get { return m_usuarioId; }
            set { m_usuarioId = value; }
        }

        public string Nome
        {
            get { return m_nome; }
            set { m_nome = value; }
        }

        public string Formacao
        {
            get { return m_formacao; }
            set { m_formacao = value; }
        }

        public string Telefone
        {
            get { return m_telefone; }
            set { m_telefone = value; }
        }

        public string Email
        {
            get { return m_email; }
            set { m_email = value; }
        }

        public string Login
        {
            get { return m_login; }
            set { m_login = value; }
        }

        public string Senha
        {
            get { return m_senha; }
            set { m_senha = value; }
        }

    }

}
