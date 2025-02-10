/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* AppDatabase.cs
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

using GEDWEBAPP.Apps.NoSql;
using GEDWEBAPP.Apps.Record;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEDWEBAPP.Apps.Base
{

    public class AppDatabase
    {
    //Private
        private UsuarioNoSql m_tblUsuario;
        private DocumentoNoSql m_tblDocumento;
        private DocumentoRevisaoNoSql m_tblDocumentoRevisao;

    //Public

        public AppDatabase()
        {
            init();
        }

        /* Methodes */

        public void init()
        {
            AppMain app = AppMain.getApp();
            AppCtx ctx = app.getCtx();

            string fileTblUsuario = ctx.DataDir + AppDefs.NOSQL_TBLFILE_USUARIO;
            m_tblUsuario = new UsuarioNoSql(fileTblUsuario);

            string fileTblDocumento = ctx.DataDir + AppDefs.NOSQL_TBLFILE_DOCUMENTO;
            m_tblDocumento = new DocumentoNoSql(fileTblDocumento);

            string fileTblDocumentoRevisao = ctx.DataDir + AppDefs.NOSQL_TBLFILE_DOCUMENTOREVISAO;
            m_tblDocumentoRevisao = new DocumentoRevisaoNoSql(fileTblDocumentoRevisao);
        }

        /* CREATE / LOAD / SAVE */

        public void createAll()
        {
            m_tblUsuario.create();
            m_tblDocumento.create();
            m_tblDocumentoRevisao.create();
        }

        public void loadAll()
        {
            m_tblUsuario.load();
            m_tblDocumento.load();
            m_tblDocumentoRevisao.load();
        }

        public void saveAll()
        {
            m_tblUsuario.save();
            m_tblDocumento.save();
            m_tblDocumentoRevisao.save();
        }

        /* Database */

        //TABELA_USUARIO
        //
        public UsuarioRecord findUsuarioByPk(int usuarioId)
        {
            UsuarioRecord oResult = m_tblUsuario.selectByPk(usuarioId);
            return oResult;
        }

        //TABELA_DOCUMENTO
        //
        public DocumentoRecord findDocumentoByPk(int documentoId)
        {
            DocumentoRecord oResult = m_tblDocumento.selectByPk(documentoId);
            return oResult;
        }

        public List<DocumentoRecord> findAllDocumento()
        {
            List<DocumentoRecord> lsResult = m_tblDocumento.selectAll();
            return lsResult;
        }

        //TABELA_DOCUMENTO_REVISAO
        //
        public List<DocumentoRevisaoRecord> findAllDocumentoRevisaoByDocumentoId(int documentoId)
        {
            List<DocumentoRevisaoRecord> lsResult = m_tblDocumentoRevisao.selectByDocumentoId(documentoId);
            return lsResult;
        }

    }

}
