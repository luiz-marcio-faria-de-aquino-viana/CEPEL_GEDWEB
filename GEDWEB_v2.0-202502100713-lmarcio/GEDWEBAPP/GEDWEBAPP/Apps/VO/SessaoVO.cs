using GEDWEBAPP.Apps.Base;
using GEDWEBAPP.Apps.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEDWEBAPP.Apps.VO
{
    public class SessaoVO
    {
    //Private Static
        private static int gSeqNum = AppDefs.DEF_SEQ_SESSAO_INIT;

    //Private
        private int m_sessaoId;
        private int m_usuarioId;
        private string m_nome;
        private string m_formacao;
        private string m_telefone;
        private string m_email;
        private string m_login;
        private string m_senha;

    //Public

        public SessaoVO(UsuarioRecord o)
        {
            init(o);
        }

        /* Methodes */

        public void init(UsuarioRecord o)
        {
            m_sessaoId = SessaoVO.nextSeq();
            m_usuarioId = o.UsuarioId;
            m_nome = o.Nome;
            m_formacao = o.Formacao;
            m_telefone = o.Telefone;
            m_email = o.Email;
            m_login = o.Login;
            m_senha = o.Senha;
        }

        /* DEBUG */

        public string toStr()
        {
            string str = string.Format(
                "SessaoId:{0};" +
                "UsuarioId:{1};" +
                "Nome:{2};" +
                "Formacao:{3};" +
                "Telefone:{4};" +
                "Email:{5};" +
                "Login:{6};" +
                "Senha:{7}\n",
                m_sessaoId,
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

            string warnmsg = this.toStr();
            AppError.showWarn(debugLevel, warnmsg, this.GetType().ToString());   
        }

        /* Sequence */

        public static int initSeq(int seqNum)
        {
            SessaoVO.gSeqNum = seqNum;
            return SessaoVO.gSeqNum;
        }

        public static int currSeq()
        {
            return SessaoVO.gSeqNum;
        }

        public static int nextSeq()
        {
            int result = SessaoVO.gSeqNum++;

            if (SessaoVO.gSeqNum >= AppDefs.DEF_SEQ_SESSAO_END)
            {
                SessaoVO.gSeqNum = AppDefs.DEF_SEQ_SESSAO_INIT;
            }
            return result;
        }

        /* Getters/Setters */

        public int SessaoId
        {
            get { return m_sessaoId; }
            set { m_sessaoId = value; }
        }

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
