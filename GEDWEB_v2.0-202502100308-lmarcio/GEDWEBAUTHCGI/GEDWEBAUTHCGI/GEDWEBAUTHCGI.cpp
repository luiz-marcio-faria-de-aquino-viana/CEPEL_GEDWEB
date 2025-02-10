/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* GEDWEBAUTHCGI.cpp
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 07/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

#include"stdafx.h"
#include "All.h"

CGedWebAuthCGI* gApp = NULL;

CGedWebAuthCGI::CGedWebAuthCGI()
{
	init();
}

CGedWebAuthCGI::~CGedWebAuthCGI()
{
	terminate();
}

void CGedWebAuthCGI::doOutputHeader()
{
	wprintf(_T("Content-type: text/xml\n\n"));

	wprintf(_T("<?xml version='1.0' ?>\n"));
	wprintf(_T("<CEPEL_GEDWEB>\n"));
	wprintf(_T("<CEPEL_Header>\n"));

	bigstr_t strArquivoDados;

	strNCpyUtil(strArquivoDados, m_ptrCtx->getRepositorioDir(), BIGSTRSZ);
	strNCatUtil(strArquivoDados, m_ptrRequestData->getArquivoDados(), BIGSTRSZ);

	long szArquivoDados = sizeDataFileUtil(strArquivoDados);

	long szPtrData = szArquivoDados / sizeof(TCHAR);

	wprintf(_T("<CEPEL_ArquivoDadosNome>%s</CEPEL_ArquivoDadosNome>\n"), strArquivoDados);
	wprintf(_T("<CEPEL_ArquivoDadosTamanhoBytes>%ld</CEPEL_ArquivoDadosTamanhoBytes>\n"), szArquivoDados);
	wprintf(_T("<CEPEL_ArquivoDadosTamanhoChars>%ld</CEPEL_ArquivoDadosTamanhoChars>\n"), szPtrData);

	bigstr_t strModeloDocumento;
	strNCpyUtil(strModeloDocumento, m_ptrCtx->getTemplateFile(), BIGSTRSZ);

	long szModeloDocumento = sizeDataFileUtil(strModeloDocumento);

	long szPtrModeloDocumento = szModeloDocumento / sizeof(TCHAR);

	wprintf(_T("<CEPEL_ModeloDocumentoNome>%s</CEPEL_ModeloDocumentoNome>\n"), strModeloDocumento);
	wprintf(_T("<CEPEL_ModeloDocumentoTamanhoBytes>%ld</CEPEL_ModeloDocumentoTamanhoBytes>\n"), szModeloDocumento);
	wprintf(_T("<CEPEL_ModeloDocumentoTamanhoChars>%ld</CEPEL_ModeloDocumentoTamanhoChars>\n"), szPtrModeloDocumento);

	wprintf(_T("</CEPEL_Header>\n"));

	wprintf(_T("</CEPEL_GEDWEB>\n"));
}

void CGedWebAuthCGI::doOutput()
{
	wprintf(_T("Content-type: text/xml\n\n"));

	wprintf(_T("<?xml version='1.0' ?>\n"));
	wprintf(_T("<CEPEL_GEDWEB>\n"));

	bigstr_t strArquivoDados;

	strNCpyUtil(strArquivoDados, m_ptrCtx->getRepositorioDir(), BIGSTRSZ);
	strNCatUtil(strArquivoDados, m_ptrRequestData->getArquivoDados(), BIGSTRSZ);

	long szArquivoDados = sizeDataFileUtil(strArquivoDados);

	long szPtrData = szArquivoDados / sizeof(TCHAR);

	bigstr_t strModeloDocumento;
	strNCpyUtil(strModeloDocumento, m_ptrCtx->getTemplateFile(), BIGSTRSZ);

	long szModeloDocumento = sizeDataFileUtil(strModeloDocumento);

	long szPtrModeloDocumento = szModeloDocumento / sizeof(TCHAR);

	TCHAR* ptrData = (TCHAR*)allocData(szArquivoDados + 1);
	if (ptrData != NULL) {
		int rscode = readDataFileUtil(strArquivoDados, ptrData, szPtrData);
		if (rscode == RSOK) {
			TCHAR* ptrModeloDocumento = (TCHAR*)allocData(szModeloDocumento + 1);
			if (ptrModeloDocumento != NULL) {
				int rscode = readDataFileUtil(strModeloDocumento, ptrModeloDocumento, szPtrModeloDocumento);
				if (rscode == RSOK) {
					ULng hash = getHash(ptrData);

					wprintf(_T("<CEPEL_DocumentoCompleto>"));
					wprintf(
						ptrModeloDocumento,
						m_ptrRequestData->getDocumentoRevisaoId(),
						m_ptrRequestData->getDocumentoId(),
						m_ptrRequestData->getDocumentoNome(),
						m_ptrRequestData->getDocumentoNomeArquivo(),
						m_ptrRequestData->getDocumentoDescricao(),
						m_ptrRequestData->getDocumentoData(),
						m_ptrRequestData->getDocumentoRevisaoData(),
						m_ptrRequestData->getAutorId(),
						m_ptrRequestData->getAutorNome(),
						m_ptrRequestData->getAutorFormacao(),
						m_ptrRequestData->getAutorEmail(),
						m_ptrRequestData->getAutorTelefone(),
						m_ptrRequestData->getUsuarioId(),
						m_ptrRequestData->getUsuarioNome(),
						m_ptrRequestData->getUsuarioEmail(),
						m_ptrRequestData->getUsuarioTelefone(),
						ptrData);
					wprintf(_T("</CEPEL_DocumentoCompleto>\n"));
					wprintf(_T("<CEPEL_Signature><![CDATA[%uld]]></CEPEL_Signature>\n"), hash);

					freeData(ptrModeloDocumento);
				}
			}

			freeData(ptrData);
		}
	}

	wprintf(_T("</CEPEL_GEDWEB>\n"));
}

void CGedWebAuthCGI::doOutputAsAttachment()
{
	wprintf(_T("Content-type: text/html\n"));
	wprintf(_T("Content-disposition: attachment;filename=GEDWEB-%s\n"), m_ptrRequestData->getDocumentoNomeArquivo());
	wprintf(_T("Cache-control: no-cache\n\n"));

	wprintf(_T("Content-type: text/xml\n\n"));

	wprintf(_T("<?xml version='1.0' ?>\n"));
	wprintf(_T("<CEPEL_GEDWEB>\n"));

	bigstr_t strArquivoDados;

	strNCpyUtil(strArquivoDados, m_ptrCtx->getRepositorioDir(), BIGSTRSZ);
	strNCatUtil(strArquivoDados, m_ptrRequestData->getArquivoDados(), BIGSTRSZ);

	long szArquivoDados = sizeDataFileUtil(strArquivoDados);

	long szPtrData = szArquivoDados / sizeof(TCHAR);

	bigstr_t strModeloDocumento;
	strNCpyUtil(strModeloDocumento, m_ptrCtx->getTemplateFile(), BIGSTRSZ);

	long szModeloDocumento = sizeDataFileUtil(strModeloDocumento);

	long szPtrModeloDocumento = szModeloDocumento / sizeof(TCHAR);

	TCHAR* ptrData = (TCHAR*)allocData(szArquivoDados + 1);
	if (ptrData != NULL) {
		int rscode = readDataFileUtil(strArquivoDados, ptrData, szPtrData);
		if (rscode == RSOK) {
			TCHAR* ptrModeloDocumento = (TCHAR*)allocData(szModeloDocumento + 1);
			if (ptrModeloDocumento != NULL) {
				int rscode = readDataFileUtil(strModeloDocumento, ptrModeloDocumento, szPtrModeloDocumento);
				if (rscode == RSOK) {
					ULng hash = getHash(ptrData);

					wprintf(_T("<CEPEL_DocumentoCompleto>"));
					wprintf(
						ptrModeloDocumento,
						m_ptrRequestData->getDocumentoRevisaoId(),
						m_ptrRequestData->getDocumentoId(),
						m_ptrRequestData->getDocumentoNome(),
						m_ptrRequestData->getDocumentoNomeArquivo(),
						m_ptrRequestData->getDocumentoDescricao(),
						m_ptrRequestData->getDocumentoData(),
						m_ptrRequestData->getDocumentoRevisaoData(),
						m_ptrRequestData->getAutorId(),
						m_ptrRequestData->getAutorNome(),
						m_ptrRequestData->getAutorFormacao(),
						m_ptrRequestData->getAutorEmail(),
						m_ptrRequestData->getAutorTelefone(),
						m_ptrRequestData->getUsuarioId(),
						m_ptrRequestData->getUsuarioNome(),
						m_ptrRequestData->getUsuarioEmail(),
						m_ptrRequestData->getUsuarioTelefone(),
						ptrData);
					wprintf(_T("</CEPEL_DocumentoCompleto>\n"));
					wprintf(_T("<CEPEL_Signature><![CDATA[%uld]]></CEPEL_Signature>\n"), hash);

					freeData(ptrModeloDocumento);
				}
			}

			freeData(ptrData);
		}
	}

	wprintf(_T("</CEPEL_GEDWEB>\n"));
}

void CGedWebAuthCGI::init()
{
	_wdupenv_s(& m_ptrHomeDir, & m_szPtrHomeDir, APP_HOME);
	if (m_ptrHomeDir == NULL) {
		m_ptrCtx = new CCtx(CTX_HOMEDIR);
	}
	else {
		m_ptrCtx = new CCtx(m_ptrHomeDir);
	}

	_wdupenv_s(& m_ptrRequestMehod, & m_szPtrRequestMehod, CGI_REQUEST_METHOD);
	if (m_ptrRequestMehod == NULL) exit(1);

	_wdupenv_s(&m_ptrQueryString, &m_szPtrQueryString, CGI_QUERY_STRING);
	if (m_ptrQueryString == NULL) exit(1);

	m_ptrRequestData = new CRequestData(m_ptrQueryString);
}

void CGedWebAuthCGI::execute()
{
	//doOutputHeader();
	//doOutput();
	doOutputAsAttachment();
}

void CGedWebAuthCGI::terminate()
{
	if (m_ptrHomeDir != NULL)
		freeData(m_ptrHomeDir);

	if (m_ptrRequestMehod != NULL)
		freeData(m_ptrRequestMehod);

	if (m_ptrQueryString != NULL)
		freeData(m_ptrQueryString);

	if (m_ptrRequestData != NULL)
		delete(m_ptrRequestData);
}

/* DEBUG */

TCHAR* CGedWebAuthCGI::toStr(TCHAR* ptrStr, size_t szPtrStr)
{
	swprintf(ptrStr, szPtrStr, _T("RequestMethod:%s;QueryString:%s\n"), m_ptrRequestMehod, m_ptrQueryString);
	return ptrStr;
}

void CGedWebAuthCGI::debug(int debugLevel)
{
	if (debugLevel != DEBUG_LEVEL) return;

	bigstr_t str;
	toStr(str, BIGSTRSZ);

	warnMsg(debugLevel, __GEDWEBAUTHCGI_H, _T("debug"), str);
}

/* Getters/Setters */

CCtx* CGedWebAuthCGI::getCtx()
{
	return  m_ptrCtx;
}

TCHAR* CGedWebAuthCGI::getRequestMethod()
{
	return m_ptrRequestMehod;
}

size_t CGedWebAuthCGI::getSzRequestMethod()
{
	return m_szPtrRequestMehod;
}

TCHAR* CGedWebAuthCGI::getQueryString()
{
	return m_ptrQueryString;
}

size_t CGedWebAuthCGI::getSzQueryString()
{
	return m_szPtrQueryString;
}

/* MAIN */

int execApp(int argc, TCHAR* argv[])
{
	gApp = new CGedWebAuthCGI();
	gApp->execute();

	return 0;
}

//#define __TESTMODE__	_T("TESTMODDE");

int _tmain(int argc, TCHAR* argv[])
{
	int rscode = -1;
#ifndef __TESTMODE__
	rscode = execApp(argc, argv);
#else
	rscode = testApp(argc, argv);
#endif
	return rscode;
}
