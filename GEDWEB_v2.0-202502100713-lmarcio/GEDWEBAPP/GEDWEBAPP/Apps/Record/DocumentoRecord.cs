/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* DocumentoRecord.cs
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

    public class DocumentoRecord
    {
    //Private
        private int m_documentoId;
        private string m_documentoNome;
        private string m_documentoNomeArquivo;
        private string m_documentoDescricao;
        private string m_documentoData;
        private int m_autorId;

    //Public

        public DocumentoRecord()
        {
            init(
                AppDefs.NULL_INT,
                AppDefs.NULL_STR,
                AppDefs.NULL_STR,
                AppDefs.NULL_STR,
                AppDefs.NULL_STR,
                AppDefs.NULL_INT);
        }

        /* Methodes */

        public void init(
            int documentoId,
            string documentoNome,
            string documentoNomeArquivo,
            string documentoDescricao,
            string documentoData,
            int autorId)
        {
            m_documentoId = documentoId;
            m_documentoNome = documentoNome;
            m_documentoNomeArquivo = documentoNomeArquivo;
            m_documentoDescricao = documentoDescricao;
            m_documentoData = documentoData;
            m_autorId = autorId;
        }

        /* DATA */

        public static string toDataStoreHeader()
        {
            string strOut = "DocumentoId^DocumentoNome^DocumentoNomeArquivo^DocumentoDescricao^DocumentoData,AutorId\n";
            return strOut;
        }

        public string toDataStore()
        {
            string strOut = string.Format(
                "{0}^{1}^{2}^{3}^{4}^{5}\n",
                m_documentoId,
                m_documentoNome,
                m_documentoNomeArquivo,
                m_documentoDescricao,
                m_documentoData,
                m_autorId);
            return strOut;
        }

        public void fromDataStore(string str)
        {
            string[] arr = str.Split('^');
            if (arr.Length >= 6) {
                m_documentoId = int.Parse(arr[0]);
                m_documentoNome = arr[1];
                m_documentoNomeArquivo = arr[2];
                m_documentoDescricao = arr[3];
                m_documentoData = arr[4];
                m_autorId = int.Parse(arr[5]);
            }
        }

        /* DEBUG */

        public string toStr()
        {
            string str = string.Format(
                "DocumentoId:{0};" +
                "DocumentoNome:{1};" +
                "DocumentoNomeArquivo:{2};" +
                "DocumentoDescricao:{3};" +
                "DocumentoData:{4}\n" +
                "DocumentoData:{5}\n",
                m_documentoId,
                m_documentoNome,
                m_documentoNomeArquivo,
                m_documentoDescricao,
                m_documentoData,
                m_autorId);
            return str;
        }

        public void debug(int debugLevel)
        {
            if (debugLevel != AppDefs.DEBUG_LEVEL) return;

            string str = this.toStr();
            AppError.showWarn(debugLevel, str, this.GetType().ToString());
        }

        /* Getters/Setters */

        public int DocumentoId
        {
            get { return m_documentoId; }
            set { m_documentoId = value; }
        }

        public string DocumentoNome
        {
            get { return m_documentoNome; }
            set { m_documentoNome = value; }
        }

        public string DocumentoNomeArquivo
        {
            get { return m_documentoNomeArquivo; }
            set { m_documentoNomeArquivo = value; }
        }

        public string DocumentoDescricao
        {
            get { return m_documentoDescricao; }
            set { m_documentoDescricao = value; }
        }

        public string DocumentoData
        {
            get { return m_documentoData; }
            set { m_documentoData = value; }
        }

        public int AutorId
        {
            get { return m_autorId; }
            set { m_autorId = value; }
        }

    }

}
