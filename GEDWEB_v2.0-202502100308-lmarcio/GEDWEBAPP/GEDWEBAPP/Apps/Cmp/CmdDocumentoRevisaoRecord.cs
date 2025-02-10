/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* CmpDocumentoRevisaoRecord.cs
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEDWEBAPP.Apps.Cmp
{

    public class CmpDocumentoRevisaoRecord :
        IComparer<DocumentoRevisaoRecord>
    {
        //Private
        private bool m_bAsc = true;

        /* Methodes */

        public int compareAsc(DocumentoRevisaoRecord o1, DocumentoRevisaoRecord o2)
        {
            string nome1 = o1.getKey1();
            string nome2 = o2.getKey1();

            int result = nome1.CompareTo(nome2);
            return result;
        }

        public int compareDesc(DocumentoRevisaoRecord o1, DocumentoRevisaoRecord o2)
        {
            string nome1 = o1.getKey1();
            string nome2 = o2.getKey1();

            int result = nome2.CompareTo(nome1);
            return result;
        }

        //Public

        public CmpDocumentoRevisaoRecord(bool bAsc)
        {
            this.m_bAsc = bAsc;
        }

        /* Methodes */

        public int Compare(DocumentoRevisaoRecord o1, DocumentoRevisaoRecord o2)
        {
            int result = 0;

            if (this.m_bAsc)
                result = this.compareAsc(o1, o2);
            else
                result = this.compareDesc(o1, o2);
            return result;
        }

    }

}
