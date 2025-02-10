/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* RequestData.h
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

#pragma once

#ifndef __REQUESTDATA_H
#define __REQUESTDATA_H								_T("__REQUESTDATA_H")

class CRequestData
{
private:
	bigstr_t m_queryString;
	//
	bigstr_t m_txtDocumentoRevisaoId;
	bigstr_t m_txtDocumentoId;
	bigstr_t m_txtDocumentoNome;
	bigstr_t m_txtDocumentoNomeArquivo;
	bigstr_t m_txtDocumentoDescricao;
	bigstr_t m_txtDocumentoData;
	bigstr_t m_txtDocumentoRevisaoData;
	bigstr_t m_txtAutorId;
	bigstr_t m_txtAutorNome;
	bigstr_t m_txtAutorFormacao;
	bigstr_t m_txtAutorEmail;
	bigstr_t m_txtAutorTelefone;
	bigstr_t m_txtUsuarioId;
	bigstr_t m_txtUsuarioNome;
	bigstr_t m_txtUsuarioEmail;
	bigstr_t m_txtUsuarioTelefone;
	bigstr_t m_txtArquivoDados;
	bigstr_t m_txtArquivoSaida;
	bigstr_t m_btnEnviar;

	/* Methodes */

	TCHAR* parseParam(TCHAR* ptrParam, int szPtrParam, int n);	

	//PARSE_QUERY_STRING
	//
	//txtDocumentoRevisaoId=2100010&
	//txtDocumentoId=1100001&
	//txtDocumentoNome=GALAX+--+FUNDAMENTOS+DE+COMPUTADORES+DIGITAIS&
	//txtDocumentoNomeArquivo=GALAX.MAC&
	//txtDocumentoDescricao=Jogo+Desenvolvido+100%25+em+Assembler+Z80+para+a+Disciplina+de+Fundamentos+de+Computadores+Digitais+do+Professor+Orlando+%28UERJ%29&
	//txtDocumentoData=20250207+20%3A40&
	//txtDocumentoRevisaoData=20250207+20%3A58&
	//txtAutorId=9100001&
	//txtAutorNome=Luiz+Marcio+Faria+de+Aquino+Viana%2C+Pos-D.Sc.&
	//txtAutorFormacao=Engenheiro+Eletricista+com+Enfase+em+Engenharia+de+Sistemas+e+Computacao&
	//txtAutorEmail=luiz.marcio.viana%40gmail.com&
	//txtAutorTelefone=%2821%2999983-7207&
	//txtUsuarioId=8100001&
	//txtUsuarioNome=Luiz+Marcio+Faria+de+Aquino+Viana%2C+Pos-D.Sc.&
	//txtUsuarioEmail=luiz.marcio.viana%40gmail.com&
	//txtUsuarioTelefone=%2821%2999983-7207&
	//txtArquivoDados=C%3A%5C9998-CEPEL%5C001-GEDWEB%5CRepositorio%5C2100010-GEDWEB-GALAX_MAC.%24&
	//txtArquivoSaida=C%3A%5C9998-CEPEL%5C001-GEDWEB%5CWeb%5CGEDWEB%5Cdocs%5Coutput-202502080757123456.xml&
	//btnEnviar=Enviar
	void parseQueryString();

public:

	CRequestData(TCHAR* ptrQueryString);
	~CRequestData();

	/* Methodes */

	void init(TCHAR* ptrQueryString);

	/* Getters/Setters */

	TCHAR* getQueryString();
	//
	TCHAR* getDocumentoRevisaoId();
	TCHAR* getDocumentoId();
	TCHAR* getDocumentoNome();
	TCHAR* getDocumentoNomeArquivo();
	TCHAR* getDocumentoDescricao();
	TCHAR* getDocumentoData();
	TCHAR* getDocumentoRevisaoData();
	TCHAR* getAutorId();
	TCHAR* getAutorNome();
	TCHAR* getAutorFormacao();
	TCHAR* getAutorEmail();
	TCHAR* getAutorTelefone();
	TCHAR* getUsuarioId();
	TCHAR* getUsuarioNome();
	TCHAR* getUsuarioEmail();
	TCHAR* getUsuarioTelefone();
	TCHAR* getArquivoDados();
	TCHAR* getArquivoSaida();

};

#endif
