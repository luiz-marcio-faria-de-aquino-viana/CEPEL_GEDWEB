/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* AppDefs.cs
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GEDWEBAPP.Apps.Base
{

    public class AppDefs
    {
    //Public
        public static int DEBUG_LEVEL00 = 0;
        public static int DEBUG_LEVEL01 = 1;
        public static int DEBUG_LEVEL02 = 2;
        public static int DEBUG_LEVEL03 = 3;
        public static int DEBUG_LEVEL04 = 4;
        public static int DEBUG_LEVEL05 = 5;
        //
        public static int DEBUG_LEVEL99 = 99;

        public static int DEBUG_LEVEL = AppDefs.DEBUG_LEVEL01;

        public static string APP_NAME = "GEDWEBSERVR";

        public static string APP_VERSAO = "1.0.20250208";

        public static string APP_COPYRIGHT = "Copyright(C) 2025 TLMV Consultoria e Sistemas EIRELI. All Rights Reserved.";

        public static string APP_AUTHOR_NAME = "Autor: Luiz Marcio Faria de Aquino Viana, Pos-D.Sc.";
        public static string APP_AUTHOR_REGISTRO = "CPF: 024.723.347-10 - RG: 08855128-8 IFP-RJ - Registro: 2000103581 CREA-RJ";
        public static string APP_AUTHOR_EMAIL = "E-mail: luiz.marcio.viana@gmail.com";
        public static string APP_AUTHOR_TELEFONE = "Telefone: +55-21-99983-7207";

        public static string APP_HOME = "GEDWEBSERVR_HOME";

        //RESULT_CODES
        //
        public static int RSERR = -1;
        public static int RSOK = 0;

        //TRUE/FALSE VALUES
        //
        public static int DBFALSE = 0;
        public static int DBTRUE = 1;

        //DEFAULT_EXTENSIONS
        //
        public static string EXT_ARQUIVODADOS = "dat";
        public static string EXT_ARQUIVOTEMPLATES = "tpl";
        public static string EXT_ARQUIVOSAIDA = "xml";

        //DEFAULT_TIMEMILE
        //
        public static long H24 = (24L * 60L * 60L * 1000L);
        //
        public static long D1 = (1L * 24L * 60L * 60L * 1000L);
        public static long D2 = (2L * 24L * 60L * 60L * 1000L);
        public static long D3 = (3L * 24L * 60L * 60L * 1000L);
        public static long D4 = (4L * 24L * 60L * 60L * 1000L);
        public static long D5 = (5L * 24L * 60L * 60L * 1000L);
        public static long D10 = (10L * 24L * 60L * 60L * 1000L);
        public static long D30 = (30L * 24L * 60L * 60L * 1000L);
        public static long D60 = (60L * 24L * 60L * 60L * 1000L);

        //CONTEXT_DEFINITIONS
        //
        public static string CTX_HOMEDIR = "C:\\9998-CEPEL\\001-GEDWEB\\";
        //
        public static string CTX_BINDIR = "Bin\\";
        public static string CTX_CONFDIR = "Conf\\";
        public static string CTX_DATADIR = "Data\\";
        public static string CTX_DOCSDIR = "Docs\\";
        public static string CTX_REPOSITORIODIR = "Repositorio\\";
        public static string CTX_TEMPLATESDIR = "Templates\\";
        public static string CTX_OUTPUTDIR = "Web\\GEDWEB\\docs\\";
        //
        public static string CTX_CONFFILE = "cepel_config.cfg";
        public static string CTX_CONFFILEDEFAULT = "cepel_config-default.cfg";
        //
        public static string CTX_TEMPLATEFILE = "202502081407-GEDWEB-Modelo_Documento.tpl";

        //CONFIG_TAGS
        //
        public static string CFG_TAG_CONFIGURACAO = "Configuracao";
        public static string CFG_TAG_CONFIGURACAO_TIPOAMBIENTE = "TipoAmbiente";
        public static string CFG_TAG_CONFIGURACAO_LOCALREPOSITORIO = "LocalRepositorio";

        /* KEY VALUES
        */
        public static char K_CR = '\n';
        public static char K_LF = '\r';

        //NULL_VALUES
        //
        public static int NULL_INT = -1;
        public static char NULL_CHAR = '\0';
        public static double NULL_DBL = 0.0;
        public static string NULL_STR = "?";
        public static DateTime NULL_DATETIME = DateTime.MinValue;

        //FORMAT_DATE_DEFINITIONS
        //
        public static string DEF_DATE_TYPE1_PTBR_MASC = "dd/MM/yyyy";
        public static string DEF_DATE_TYPE2_MASC = "yyyy-MM-dd";
        public static string DEF_DATE_TYPE3_MASC = "yyyyMMdd";

        //FORMAT_DATETIME_DEFINITIONS
        //
        public static string DEF_DATETIME_TYPE1_PTBR_MASC = "dd/MM/yyyy HH:mm:ss";
        public static string DEF_DATETIME_TYPE2_MASC = "yyyyMMdd_HHmmss";
        public static string DEF_DATETIME_TYPE3_MASC = "yyyyMMddHHmmss";

        //SEQUENCE_VALUE_RANGE
        //
        //SEQ_USUARIO
        public static int DEF_SEQ_USUARIO_INIT = 1100001;
        public static int DEF_SEQ_USUARIO_END = 1199999;
        //
        //SEQ_DOCUMENTO
        public static int DEF_SEQ_DOCUMENTO_INIT = 2100001;
        public static int DEF_SEQ_DOCUMENTO_END = 2199999;
        //
        //SEQ_DOCUMENTO_REVISAO
        public static int DEF_SEQ_DOCUMENTOREVISAO_INIT = 3100001;
        public static int DEF_SEQ_DOCUMENTOREVISAO_END = 3199999;

        //TEMPLATE TAGS
        //
        public static string TEMPLTAG_DOCUMENTO_REVISAO_ID = "#DocumentoRevisaoId#";
        public static string TEMPLTAG_DOCUMENTO_ID = "#DocumentoId#";
        public static string TEMPLTAG_DOCUMENTO_NOME = "#DocumentoNome#";
        public static string TEMPLTAG_DOCUMENTO_NOME_ARQUIVO = "#DocumentoNomeArquivo#";
        public static string TEMPLTAG_DOCUMENTO_DESCRICAO = "#DocumentoDescricao#";
        public static string TEMPLTAG_DOCUMENTO_DATA = "#DocumentoData#";
        public static string TEMPLTAG_DOCUMENTO_DOCUMENTO_REVISAO_DATA = "#DocumentoRevisaoData#";
        public static string TEMPLTAG_AUTOR_ID = "#AutorId#";
        public static string TEMPLTAG_AUTOR_NOME = "#AutorNome#";
        public static string TEMPLTAG_AUTOR_FORMACAO = "#AutorFormacao#";
        public static string TEMPLTAG_AUTOR_EMAIL = "#AutorEmail#";
        public static string TEMPLTAG_AUTOR_TELEFONE = "#AutorTelefone#";
        public static string TEMPLTAG_USUARIO_ID = "#UsuarioId#";
        public static string TEMPLTAG_USUARIO_NOME = "#UsuarioNome#";
        public static string TEMPLTAG_USUARIO_EMAIL = "#UsuarioEmail#";
        public static string TEMPLTAG_USUARIO_TELEFONE = "#UsuarioTelefone#";
        public static string TEMPLTAG_DATA = "#Data#";
        public static string TEMPLTAG_SIGNATURE = "#Signature#";

        //NOSQL - TABLE_FILES
        //
        public static string NOSQL_TBLFILE_USUARIO = "TblUsuario.db";
        public static string NOSQL_TBLFILE_DOCUMENTO = "TblDocumento.db";
        public static string NOSQL_TBLFILE_DOCUMENTOREVISAO = "TblDocumentoRevisao.db";

    }

}
