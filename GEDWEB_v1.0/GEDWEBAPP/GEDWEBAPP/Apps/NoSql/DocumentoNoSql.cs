/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* DocumentoNoSql.cs
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

    public class DocumentoNoSql
    {
        //Private Static
        private static int gSeqNum = AppDefs.DEF_SEQ_DOCUMENTO_INIT;

        //Private
        private string m_fileName;

        private Hashtable m_tblDocumento;
        private Hashtable m_idxDocumentoNome;

        //Public

        public DocumentoNoSql(string fileName)
        {
            init(fileName);
        }

        /* Methodes */

        public void init(string fileName)
        {
            this.m_fileName = fileName;

            this.m_tblDocumento = new Hashtable();
            this.m_idxDocumentoNome = new Hashtable();
        }

        /* CREATE / LOAD / SAVE */

        public void create()
        {
            DateTime currDateTime = DateTime.Now;

            if (!File.Exists(m_fileName))
            {
                StreamWriter fout = null;
                try
                {
                    fout = new StreamWriter(m_fileName);

                    string sbuf = DocumentoRecord.toDataStoreHeader();
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
                        DocumentoRecord o = new DocumentoRecord();
                        o.fromDataStore(sbuf);

                        this.m_tblDocumento[o.DocumentoId] = o;
                        this.m_idxDocumentoNome[o.DocumentoNome] = o;
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

                string sbuf = DocumentoRecord.toDataStoreHeader();
                fout.Write(sbuf);

                ICollection colDocumento = this.m_tblDocumento.Values;
                foreach (object o in colDocumento)
                {
                    DocumentoRecord oRec = (DocumentoRecord)o;
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

        public DocumentoRecord selectByPk(int documentoId)
        {
            DocumentoRecord oRecord = null;
            if (this.m_tblDocumento.ContainsKey(documentoId))
            {
                oRecord = (DocumentoRecord)this.m_tblDocumento[documentoId];
            }
            return oRecord;
        }

        public DocumentoRecord selectByDocumentoNome(string nome)
        {
            DocumentoRecord oRecord = null;
            if (this.m_idxDocumentoNome.ContainsKey(nome))
            {
                oRecord = (DocumentoRecord)this.m_idxDocumentoNome[nome];
            }
            return oRecord;
        }

        public List<DocumentoRecord> selectAll()
        {
            List<DocumentoRecord> lsRecord = new List<DocumentoRecord>();

            ICollection colRecord = this.m_tblDocumento.Values;
            foreach (object o in colRecord)
            {
                DocumentoRecord oDocumento = (DocumentoRecord)o;
                lsRecord.Add(oDocumento);
            }

            CmpDocumentoRecord c = new CmpDocumentoRecord(true);
            lsRecord.Sort(c);

            return lsRecord;
        }

        /* Insert/Update */

        public int insertDocumento(
            string documentoNome,
            string documentoNomeArquivo,
            string documentoDescricao,
            string documentoData)
        {
            int documentoId = DocumentoNoSql.nextSeq();

            DocumentoRecord o = new DocumentoRecord();
            o.init(
                documentoId,
                documentoNome,
                documentoNomeArquivo,
                documentoDescricao,
                documentoData);
            this.m_tblDocumento[o.DocumentoId] = o;
            this.m_idxDocumentoNome[o.DocumentoNome] = o;

            return documentoId;
        }

        public int updateDocumento(
            int documentoId,
            string documentoNome,
            string documentoNomeArquivo,
            string documentoDescricao,
            string documentoData)
        {
            int result = -1;

            DocumentoRecord o = this.selectByPk(documentoId);
            if (o != null)
            {
                o.DocumentoId = documentoId;
                o.DocumentoNome = documentoNome;
                o.DocumentoNomeArquivo = documentoNomeArquivo;
                o.DocumentoDescricao = documentoDescricao;
                o.DocumentoData = documentoData;

                result = documentoId;
            }
            return result;
        }

        public int insertUpdateDocumento(
            int documentoId,
            string documentoNome,
            string documentoNomeArquivo,
            string documentoDescricao,
            string documentoData)
        {
            int result = -1;

            if (documentoId != -1)
            {
                result = updateDocumento(
                    documentoId,
                    documentoNome,
                    documentoNomeArquivo,
                    documentoDescricao,
                    documentoData);
            }

            if (result == -1)
            {
                result = insertDocumento(
                    documentoNome,
                    documentoNomeArquivo,
                    documentoDescricao,
                    documentoData);
            }
            return result;
        }

        /* Insert/Update */

        public static int initSeq(int seqNum)
        {
            DocumentoNoSql.gSeqNum = seqNum;
            return DocumentoNoSql.gSeqNum;
        }

        public static int currSeq()
        {
            return DocumentoNoSql.gSeqNum;
        }

        public static int nextSeq()
        {
            int result = DocumentoNoSql.gSeqNum++;

            if (DocumentoNoSql.gSeqNum >= AppDefs.DEF_SEQ_USUARIO_END)
            {
                DocumentoNoSql.gSeqNum = AppDefs.DEF_SEQ_USUARIO_INIT;
            }
            return result;
        }

    }

}
