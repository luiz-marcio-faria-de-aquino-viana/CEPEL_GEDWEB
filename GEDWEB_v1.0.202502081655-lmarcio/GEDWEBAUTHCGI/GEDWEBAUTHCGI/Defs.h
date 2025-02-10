/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* Defs.h
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 07/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

#pragma once

#ifndef __DEFS_H
#define __DEFS_H									_T("__DEFS_H")

#define DEBUG_LEVEL00								0
#define DEBUG_LEVEL01								1
#define DEBUG_LEVEL02								2
#define DEBUG_LEVEL03								3
#define DEBUG_LEVEL04								4
#define DEBUG_LEVEL05								5
//
#define DEBUG_LEVEL99								99

#define DEBUG_LEVEL									1

#define APP_NAME									_T("GEDWEBCOMPAUTH")

#define APP_VERSAO									_T("1.0.20250207")

#define APP_COPYRIGHT								_T("Copyright(C) 2025 TLMV Consultoria e Sistemas EIRELI. All Rights Reserved.")

#define APP_AUTHOR_NAME								_T("Autor: Luiz Marcio Faria de Aquino Viana, Pos-D.Sc.")
#define APP_AUTHOR_REGISTRO							_T("CPF: 024.723.347-10 - RG: 08855128-8 IFP-RJ - Registro: 2000103581 CREA-RJ")
#define APP_AUTHOR_EMAIL							_T("E-mail: luiz.marcio.viana@gmail.com")
#define APP_AUTHOR_TELEFONE							_T("Telefone: +55-21-99983-7207")

#define APP_HOME									_T("GEDWEBCOMPAUTH_HOME")

#define HLP_USAGE_INFO								_T("HELP - Uso: GEDWEBCOMPAUTH -metadados [METADATA_FILE_NAME] -datafile [DATA_FILE_NAME] -outputfile [OUTPUT_FILE_NAME]\n")

//RESULT_CODES
//
#define RSERR										-1
#define RSOK										0

//TRUE/FALSE VALUES
//
#define DBFALSE										0
#define DBTRUE										1

//BASIC_TYPES
//
typedef unsigned char byte;

typedef unsigned int UInt;

typedef unsigned long ULng;

#define BUFSZ										4096

typedef byte buf_t[BUFSZ];

#define STRSZ										256

typedef TCHAR str_t[STRSZ];

#define BIGSTRSZ									1024

typedef TCHAR bigstr_t[BIGSTRSZ];

//DEFAULT_EXTENSIONS
//
#define EXT_ARQUIVODADOS							_T("$")
#define EXT_METADADOS								_T("m")
#define EXT_ARQUIVOSAIDA							_T("xml")

//DEFAULT_TIMEMILE
//
#define H24											(24L * 60L * 60L * 1000L)
//
#define D1											(1L * 24L * 60L * 60L * 1000L)
#define D2											(2L * 24L * 60L * 60L * 1000L)
#define D3											(3L * 24L * 60L * 60L * 1000L)
#define D4											(4L * 24L * 60L * 60L * 1000L)
#define D5											(5L * 24L * 60L * 60L * 1000L)
#define D10											(10L * 24L * 60L * 60L * 1000L)
#define D30											(30L * 24L * 60L * 60L * 1000L)
#define D60											(60L * 24L * 60L * 60L * 1000L)

//CONTEXT_DEFINITIONS
//
#define CTX_HOMEDIR									_T("C:\\9998-CEPEL\\001-GEDWEB\\")
//
#define CTX_BINDIR									_T("Bin\\")
#define CTX_CONFDIR									_T("Conf\\")
#define CTX_DATADIR									_T("Data\\")
#define CTX_DOCSDIR									_T("Docs\\")
#define CTX_REPOSITORIODIR							_T("Repositorio\\")
#define CTX_TEMPLATESDIR							_T("Templates\\")
#define CTX_OUTPUTDIR								_T("Web\\GEDWEB\\docs\\")
//
#define CTX_CONFFILE								_T("cepel_config.cfg")
#define CTX_CONFFILEDEFAULT							_T("cepel_config-default.cfg")
//
#define CTX_TEMPLATEFILE							_T("202502081407-GEDWEB-Modelo_Documento.tpl")

//CONFIG_TAGS
//
#define CFG_TAG_CONFIGURACAO						_T("Configuracao")
#define CFG_TAG_CONFIGURACAO_TIPOAMBIENTE			_T("TipoAmbiente")
#define CFG_TAG_CONFIGURACAO_LOCALREPOSITORIO		_T("LocalRepositorio")

/* KEY VALUES
*/
#define K_CR										((TCHAR)'\n')
#define K_LF										((TCHAR)'\r')

//NULL_VALUES
//
#define NULL_INT									-1
#define NULL_CHAR									'\0'
#define NULL_DBL									0.0
#define NULL_STR									_T("?")

/* FILE MODES
*/
//ASCII
#define FILMODE_READ_ASCII							_T("r")
#define FILMODE_WRITE_ASCII							_T("w")
#define FILMODE_APPEND_ASCII						_T("a")
//BINARY
#define FILMODE_READ								_T("rb")
#define FILMODE_READ_WRITE							_T("rb+")
#define FILMODE_WRITE								_T("wb")
#define FILMODE_WRITE_TRUNCATE_DATA					_T("wb+")
#define FILMODE_APPEND								_T("ab")
#define FILMODE_READ_APPEND							_T("ab+")

/* BASE_DEFINITIONS
*/
#define MAX_NUMBER_OF_FILEOPEN_RETRY				5

#define MAX_TIMEOUT_BETWEN_FILEOPEN_RETRY			1                         // 1 secound

/* CHECK FILE ACCESS RESULT
*/
#define FILE_ACCESS_RESULT(v)						((v == -1) ? RSERR : RSOK)

//MIN and MAX
//
#define MIN(X,Y)									((X <= Y) ? X : Y)
#define MAX(X,Y)									((X >= Y) ? X : Y)

//CASESENSITIVE
//
#define DEF_CASESENSITIVE_NONE						-1
#define DEF_CASESENSITIVE_TOUPPER					1001
#define DEF_CASESENSITIVE_TOLOWER					1002

//FORMAT_DATE_DEFINITIONS
//
#define DEF_DATE_TYPE1_PTBR_MASC					_T("dd/MM/yyyy")
#define DEF_DATE_TYPE2_MASC							_T("yyyy-MM-dd")
#define DEF_DATE_TYPE3_MASC							_T("yyyyMMdd")

//FORMAT_DATETIME_DEFINITIONS
//
#define DEF_DATETIME_TYPE1_PTBR_MASC				_T("dd/MM/yyyy HH:mm:ss")
#define DEF_DATETIME_TYPE2_MASC						_T("yyyyMMdd_HHmmss")
#define DEF_DATETIME_TYPE3_MASC						_T("yyyyMMddHHmmss")

//SEQUENCE_VALUE_RANGE
//
#define DEF_SEQ_INIT								1000001
#define DEF_SEQ_END									9999999

//TEMPLATE TAGS
//
#define TEMPLTAG_DOCUMENTO_REVISAO_ID				_T("#DocumentoRevisaoId#")
#define TEMPLTAG_DOCUMENTO_ID						_T("#DocumentoId#")
#define TEMPLTAG_DOCUMENTO_NOME						_T("#DocumentoNome#")
#define TEMPLTAG_DOCUMENTO_NOME_ARQUIVO				_T("#DocumentoNomeArquivo#")
#define TEMPLTAG_DOCUMENTO_DESCRICAO				_T("#DocumentoDescricao#")
#define TEMPLTAG_DOCUMENTO_DATA						_T("#DocumentoData#")
#define TEMPLTAG_DOCUMENTO_DOCUMENTO_REVISAO_DATA	_T("#DocumentoRevisaoData#")
#define TEMPLTAG_AUTOR_ID							_T("#AutorId#")
#define TEMPLTAG_AUTOR_NOME							_T("#AutorNome#")
#define TEMPLTAG_AUTOR_FORMACAO						_T("#AutorFormacao#")
#define TEMPLTAG_AUTOR_EMAIL						_T("#AutorEmail#")
#define TEMPLTAG_AUTOR_TELEFONE						_T("#AutorTelefone#")
#define TEMPLTAG_USUARIO_ID							_T("#UsuarioId#")
#define TEMPLTAG_USUARIO_NOME						_T("#UsuarioNome#")
#define TEMPLTAG_USUARIO_EMAIL						_T("#UsuarioEmail#")
#define TEMPLTAG_USUARIO_TELEFONE					_T("#UsuarioTelefone#")
#define TEMPLTAG_DATA								_T("#Data#")
#define TEMPLTAG_SIGNATURE							_T("#Signature#")

//CGI REQUEST
//
#define CGI_REQUEST_METHOD							_T("REQUEST_METHOD")
#define CGI_QUERY_STRING							_T("QUERY_STRING")

#endif
