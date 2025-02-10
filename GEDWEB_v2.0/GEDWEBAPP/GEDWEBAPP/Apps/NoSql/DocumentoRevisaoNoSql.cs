/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* DocumentoRevisaoNoSql.cs
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

    public class DocumentoRevisaoNoSql
    {
        //Private Static
        private static int gSeqNum = AppDefs.DEF_SEQ_DOCUMENTOREVISAO_INIT;

        //Private
        private string m_fileName;

        private Hashtable m_tblDocumentoRevisao;
        private Hashtable m_idxKey1;

        //Public

        public DocumentoRevisaoNoSql(string fileName)
        {
            init(fileName);
        }

        /* Methodes */

        public void init(string fileName)
        {
            this.m_fileName = fileName;

            this.m_tblDocumentoRevisao = new Hashtable();
            this.m_idxKey1 = new Hashtable();
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

                    string sbuf = DocumentoRevisaoRecord.toDataStoreHeader();
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
                while ((sbuf = fin.ReadLine()) != null) {
                    if (pos > 0) {
                        DocumentoRevisaoRecord o = new DocumentoRevisaoRecord();
                        o.fromDataStore(sbuf);

                        this.m_tblDocumentoRevisao[o.DocumentoRevisaoId] = o;
                        this.m_idxKey1[o.getKey1()] = o;
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

            if (File.Exists(m_fileName)) {
                string bakFileName = string.Format("{0}.{1:yyyyMMddHHmmss}.bak", m_fileName, currDateTime);
                File.Copy(m_fileName, bakFileName);
            }

            StreamWriter fout = null;
            try
            {
                fout = new StreamWriter(m_fileName);

                string sbuf = DocumentoRevisaoRecord.toDataStoreHeader();
                fout.Write(sbuf);

                ICollection colDocumentoRevisao = this.m_tblDocumentoRevisao.Values;
                foreach (object o in colDocumentoRevisao)
                {
                    DocumentoRevisaoRecord oRec = (DocumentoRevisaoRecord)o;
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

        public DocumentoRevisaoRecord selectByPk(int documentoRevisaoId)
        {
            DocumentoRevisaoRecord oRecord = null;
            if (this.m_tblDocumentoRevisao.ContainsKey(documentoRevisaoId))
            {
                oRecord = (DocumentoRevisaoRecord)this.m_tblDocumentoRevisao[documentoRevisaoId];
            }
            return oRecord;
        }

        public DocumentoRevisaoRecord selectByKey1(string key1)
        {
            DocumentoRevisaoRecord oRecord = null;
            if (this.m_idxKey1.ContainsKey(key1))
            {
                oRecord = (DocumentoRevisaoRecord)this.m_idxKey1[key1];
            }
            return oRecord;
        }

        public List<DocumentoRevisaoRecord> selectAll()
        {
            List<DocumentoRevisaoRecord> lsRecord = new List<DocumentoRevisaoRecord>();

            ICollection colRecord = this.m_tblDocumentoRevisao.Values;
            foreach (object o in colRecord)
            {
                DocumentoRevisaoRecord oDocumentoRevisao = (DocumentoRevisaoRecord)o;
                lsRecord.Add(oDocumentoRevisao);
            }

            CmpDocumentoRevisaoRecord c = new CmpDocumentoRevisaoRecord(true);
            lsRecord.Sort(c);

            return lsRecord;
        }

        public List<DocumentoRevisaoRecord> selectByDocumentoId(int documentoId)
        {
            List<DocumentoRevisaoRecord> lsRecord = new List<DocumentoRevisaoRecord>();

            ICollection colRecord = this.m_tblDocumentoRevisao.Values;
            foreach (object o in colRecord)
            {
                DocumentoRevisaoRecord oDocumentoRevisao = (DocumentoRevisaoRecord)o;
                if(oDocumentoRevisao.DocumentoId == documentoId)
                    lsRecord.Add(oDocumentoRevisao);
            }

            CmpDocumentoRevisaoRecord c = new CmpDocumentoRevisaoRecord(true);
            lsRecord.Sort(c);

            return lsRecord;
        }

        /* Insert/Update */

        public int insertDocumentoRevisao(
            int documentoId,
            int numeroRevisao,
            string documentoRevisaoNomeDisco,
            string documentoRevisaoData)
        {
            int documentoRevisaoId = DocumentoRevisaoNoSql.nextSeq();

            DocumentoRevisaoRecord o = new DocumentoRevisaoRecord();
            o.init(
                documentoRevisaoId,
                documentoId,
                numeroRevisao,
                documentoRevisaoNomeDisco,
                documentoRevisaoData);
            this.m_tblDocumentoRevisao[o.DocumentoRevisaoId] = o;
            this.m_idxKey1[o.getKey1()] = o;

            return documentoRevisaoId;
        }

        public int updateDocumentoRevisao(
            int documentoRevisaoId,
            int documentoId,
            int numeroRevisao,
            string documentoRevisaoNomeDisco,
            string documentoRevisaoData)
        {
            int result = -1;

            DocumentoRevisaoRecord o = this.selectByPk(documentoRevisaoId);
            if (o != null)
            {
                o.DocumentoRevisaoId = documentoRevisaoId;
                o.DocumentoId = documentoId;
                o.NumeroRevisao = numeroRevisao;
                o.DocumentoRevisaoNomeDisco = documentoRevisaoNomeDisco;
                o.DocumentoRevisaoData = documentoRevisaoData;

                result = documentoRevisaoId;
            }
            return result;
        }

        public int insertUpdateDocumento(
            int documentoRevisaoId,
            int documentoId,
            int numeroRevisao,
            string documentoRevisaoNomeDisco,
            string documentoRevisaoData)
        {
            int result = -1;

            if (documentoId != -1)
            {
                result = updateDocumentoRevisao(
                    documentoRevisaoId,
                    documentoId,
                    numeroRevisao,
                    documentoRevisaoNomeDisco,
                    documentoRevisaoData);
            }

            if (result == -1)
            {
                result = insertDocumentoRevisao(
                    documentoId,
                    numeroRevisao,
                    documentoRevisaoNomeDisco,
                    documentoRevisaoData);
            }
            return result;
        }

        /* Sequence */

        public static int initSeq(int seqNum)
        {
            DocumentoRevisaoNoSql.gSeqNum = seqNum;
            return DocumentoRevisaoNoSql.gSeqNum;
        }

        public static int currSeq()
        {
            return DocumentoRevisaoNoSql.gSeqNum;
        }

        public static int nextSeq()
        {
            int result = DocumentoRevisaoNoSql.gSeqNum++;

            if (DocumentoRevisaoNoSql.gSeqNum >= AppDefs.DEF_SEQ_DOCUMENTOREVISAO_END)
            {
                DocumentoRevisaoNoSql.gSeqNum = AppDefs.DEF_SEQ_DOCUMENTOREVISAO_INIT;
            }
            return result;
        }

    }

}
