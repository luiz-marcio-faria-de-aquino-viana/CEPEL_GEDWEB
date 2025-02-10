/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* UsuarioNoSql.cs
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
using GEDWEBAPP.Apps.Cmp;
using GEDWEBAPP.Apps.Record;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GEDWEBAPP.Apps.NoSql
{

    public class UsuarioNoSql
    {
    //Private Static
        private static int gSeqNum = AppDefs.DEF_SEQ_USUARIO_INIT;

    //Private
        private string m_fileName;

        private Hashtable m_tblUsuario;
        private Hashtable m_idxLogin;

    //Public

        public UsuarioNoSql(string fileName)
        {
            init(fileName);
        }

        /* Methodes */

        public void init(string fileName)
        {
            this.m_fileName = fileName;

            this.m_tblUsuario = new Hashtable();
            this.m_idxLogin = new Hashtable();
        }

        /* CREATE / LOAD / SAVE */

        public void create()
        {
            DateTime currDateTime = DateTime.Now;

            if (File.Exists(m_fileName))
            {
                StreamWriter fout = null;
                try
                {
                    fout = new StreamWriter(m_fileName);

                    string sbuf = UsuarioRecord.toDataStoreHeader();
                    fout.Write(sbuf);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    if (fout != null) fout.Close();
                }
            }
        }

        public void load()
        {
            StreamReader fin = null;
            try
            {
                fin = new StreamReader(m_fileName);
                string sbuf = null;

                int pos = 0;
                while ((sbuf = fin.ReadLine()) != null)
                {
                    if (pos > 0)
                    {
                        UsuarioRecord o = new UsuarioRecord();
                        o.fromDataStore(sbuf);

                        this.m_tblUsuario[o.UsuarioId] = o;
                        this.m_idxLogin[o.Login] = o;
                    }
                    pos += 1;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fin != null) fin.Close();
            }
        }

        public void save()
        {
            DateTime currDateTime = DateTime.Now;

            if (File.Exists(m_fileName))
            {
                string bakFileName = string.Format("{0}.{1:yyyyMMddHHmmss}.bak", m_fileName, currDateTime);
                File.Copy(m_fileName, bakFileName);
            }

            StreamWriter fout = null;
            try
            {
                fout = new StreamWriter(m_fileName);

                string sbuf = UsuarioRecord.toDataStoreHeader();
                fout.Write(sbuf);

                ICollection colUsuario = this.m_tblUsuario.Values;
                foreach (object o in colUsuario)
                {
                    UsuarioRecord oRec = (UsuarioRecord)o;
                    sbuf = oRec.toDataStore();

                    fout.Write(sbuf);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if (fout != null) fout.Close();
            }
        }

        /* Selects */

        public UsuarioRecord selectByPk(int usuarioId)
        {
            UsuarioRecord oRecord = null;
            if (this.m_tblUsuario.ContainsKey(usuarioId))
            {
                oRecord = (UsuarioRecord)this.m_tblUsuario[usuarioId];
            }
            return oRecord;
        }

        public UsuarioRecord selectByLogin(string login)
        {
            UsuarioRecord oRecord = null;
            if (this.m_idxLogin.ContainsKey(login))
            {
                oRecord = (UsuarioRecord)this.m_idxLogin[login];
            }
            return oRecord;
        }

        public List<UsuarioRecord> selectAll()
        {
            List<UsuarioRecord> lsRecord = new List<UsuarioRecord>();

            ICollection colRecord = this.m_tblUsuario.Values;
            foreach(object o in colRecord) {
                UsuarioRecord oUsuario = (UsuarioRecord)o; 
                lsRecord.Add(oUsuario);
            }

            CmpUsuarioRecord c = new CmpUsuarioRecord(true);
            lsRecord.Sort(c);

            return lsRecord;
        }

        /* Insert/Update */

        public int insertUsuario(
            string nome,
            string formacao,
            string telefone,
            string email,
            string login,
            string senha)
        {
            int usuarioId = UsuarioNoSql.nextSeq();

            UsuarioRecord o = new UsuarioRecord();
            o.init(
                usuarioId,
                nome,
                formacao,
                telefone,
                email,
                login,
                senha);
            this.m_tblUsuario[o.UsuarioId] = o;
            this.m_idxLogin[o.Login] = o;

            return usuarioId;
        }

        public int updateUsuario(
            int usuarioId,
            string nome,
            string formacao,
            string telefone,
            string email,
            string login,
            string senha)
        {
            int result = -1;

            UsuarioRecord o = this.selectByPk(usuarioId);
            if (o != null) {
                o.Nome = nome;
                o.Formacao = formacao;
                o.Telefone = telefone;
                o.Email = email;
                o.Login = login;
                o.Senha = senha;

                result = usuarioId;
            }
            return result;
        }

        public int insertUpdateUsuario(
            int usuarioId,
            string nome,
            string formacao,
            string telefone,
            string email,
            string login,
            string senha)
        {
            int result = -1;

            if (usuarioId != -1) {
                result = updateUsuario(
                    usuarioId,
                    nome,
                    formacao,
                    telefone,
                    email,
                    login,
                    senha);
            }
            
            if(result == -1) {
                result = insertUsuario(
                    nome,
                    formacao,
                    telefone,
                    email,
                    login,
                    senha);
            }
            return result;
        }

        /* Sequence */

        public static int initSeq(int seqNum)
        {
            UsuarioNoSql.gSeqNum = seqNum;
            return UsuarioNoSql.gSeqNum;
        }

        public static int currSeq()
        {
            return UsuarioNoSql.gSeqNum;
        }

        public static int nextSeq()
        {
            int result = UsuarioNoSql.gSeqNum++;

            if (UsuarioNoSql.gSeqNum >= AppDefs.DEF_SEQ_USUARIO_END)
            {
                UsuarioNoSql.gSeqNum = AppDefs.DEF_SEQ_USUARIO_INIT;
            }
            return result;
        }

    }

}
