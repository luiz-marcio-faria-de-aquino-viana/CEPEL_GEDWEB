/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* DocumentoRevisaoRecord.cs
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

    public class DocumentoRevisaoRecord
    {
    //Private
        private int m_documentoRevisaoId;
        private int m_documentoId;
        private int m_numeroRevisao;
        private string m_documentoRevisaoNomeDisco;
        private string m_documentoRevisaoData;

    //Public

        public DocumentoRevisaoRecord()
        {
            init(
                AppDefs.NULL_INT,
                AppDefs.NULL_INT,
                AppDefs.NULL_INT,
                AppDefs.NULL_STR,
                AppDefs.NULL_STR);
        }

        /* Methodes */

        public void init(
            int documentoRevisaoId,
            int documentoId,
            int numeroRevisao,
            string documentoRevisaoNomeDisco,
            string documentoRevisaoData)
        {
            m_documentoRevisaoId = documentoRevisaoId;
            m_documentoId = documentoId;
            m_numeroRevisao = numeroRevisao;
            m_documentoRevisaoNomeDisco = documentoRevisaoNomeDisco;
            m_documentoRevisaoData = documentoRevisaoData;
        }

        /* DATA */

        public static string toDataStoreHeader()
        {
            string strOut = "DocumentoRevisaoId^DocumentoId^NumeroRevisao^DocumentoRevisaoNomeDisco^DocumentoRevisaoData\n";
            return strOut;
        }

        public string toDataStore()
        {
            string strOut = string.Format(
                "{0}^{1}^{2}^{3}^{4}\n",
                m_documentoRevisaoId,
                m_documentoId,
                m_numeroRevisao,
                m_documentoRevisaoNomeDisco,
                m_documentoRevisaoData);
            return strOut;
        }

        public void fromDataStore(string str)
        {
            string[] arr = str.Split('^');
            if (arr.Length >= 5)
            {
                m_documentoRevisaoId = int.Parse(arr[0]);
                m_documentoId = int.Parse(arr[1]);
                m_numeroRevisao = int.Parse(arr[2]);
                m_documentoRevisaoNomeDisco = arr[3];
                m_documentoRevisaoData = arr[4];
            }
        }

        /* DEBUG */

        public string toStr()
        {
            string str = string.Format(
                "DocumentoRevisaoId:{0};" +
                "DocumentoId:{1};" +
                "NumeroRevisao:{2};" +
                "DocumentoRevisaoNomeDisco:{3};" +
                "DocumentoRevisaoData:{4}\n",
                m_documentoRevisaoId,
                m_documentoId,
                m_numeroRevisao,
                m_documentoRevisaoNomeDisco,
                m_documentoRevisaoData);
            return str;
        }

        public void debug(int debugLevel)
        {
            if (debugLevel != AppDefs.DEBUG_LEVEL) return;

            string str = this.toStr();
            AppError.showWarn(debugLevel, str, this.GetType().ToString());
        }

        /* Getters/Setters */

        public int DocumentoRevisaoId
        {
            get { return m_documentoRevisaoId; }
            set { m_documentoRevisaoId = value; }
        }

        public int DocumentoId
        {
            get { return m_documentoId; }
            set { m_documentoId = value; }
        }

        public int NumeroRevisao
        {
            get { return m_numeroRevisao; }
            set { m_numeroRevisao = value; }
        }

        public string DocumentoRevisaoNomeDisco
        {
            get { return m_documentoRevisaoNomeDisco; }
            set { m_documentoRevisaoNomeDisco = value; }
        }

        public string DocumentoRevisaoData
        {
            get { return m_documentoRevisaoData; }
            set { m_documentoRevisaoData = value; }
        }

        //INDEX
        //
        public string getKey1()
        {
            string key1 = string.Format("K1_{0:0000000}_{1:0000000}", this.DocumentoId, this.DocumentoRevisaoId);
            return key1;
        }

    }

}
