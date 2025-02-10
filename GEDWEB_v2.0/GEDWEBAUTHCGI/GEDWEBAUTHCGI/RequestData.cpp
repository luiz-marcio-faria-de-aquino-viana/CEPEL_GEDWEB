/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* RequestData.cpp
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

#include"stdafx.h"
#include"All.h"

CRequestData::CRequestData(TCHAR* ptrQueryString)
{
	init(ptrQueryString);
}

CRequestData::~CRequestData()
{
	/* nothing todo! */
}

/* Methodes */

void CRequestData::init(TCHAR* ptrQueryString)
{
	strNCpyUtil(this->m_queryString, ptrQueryString, BIGSTRSZ);

	parseQueryString();
}

TCHAR* CRequestData::parseParam(TCHAR* ptrParam, int szPtrParam, int n)
{
	bigstr_t strTmp;

	strPieceUtil(this->m_queryString, BIGSTRSZ, strTmp, BIGSTRSZ, '&', n);
	strPieceUtil(strTmp, BIGSTRSZ, ptrParam, szPtrParam, '=', 1);
	return ptrParam;
}

//PARSE_QUERY_STRING
//
//txtDocumentoRevisaoId=2100010&
//txtDocumentoId=1100001&
//txtDocumentoNome=GALAX+--+FUNDAMENTOS+DE+COMPUTADORES+DIGITAIS&
//txtDocumentoNomeArquivo=GALAX.MAC&
//txtDocumentoDescricao=Jogo+Desenvolvido+100%25+em+Assembler+Z80+para+a+Disciplina+de+Fundamentos+de+Computadores+Digitais+do+Professor+Orlando+%28UERJ%29&
//txtDocumentoData=20250207+20%3A40&
//txtDocumentoRevisaoData=20250207+20%3A58&
//
//txtAutorId=9100001&
//txtAutorNome=Luiz+Marcio+Faria+de+Aquino+Viana%2C+Pos-D.Sc.&
//txtAutorFormacao=Engenheiro+Eletricista+com+Enfase+em+Engenharia+de+Sistemas+e+Computacao&
//txtAutorEmail=luiz.marcio.viana%40gmail.com&
//txtAutorTelefone=%2821%2999983-7207&
//
//txtUsuarioId=8100001&
//txtUsuarioNome=Luiz+Marcio+Faria+de+Aquino+Viana%2C+Pos-D.Sc.&
//txtUsuarioEmail=luiz.marcio.viana%40gmail.com&
//txtUsuarioTelefone=%2821%2999983-7207&
//
//txtArquivoDados=C%3A%5C9998-CEPEL%5C001-GEDWEB%5CRepositorio%5C2100010-GEDWEB-GALAX_MAC.%24&
//
//txtArquivoSaida=C%3A%5C9998-CEPEL%5C001-GEDWEB%5CWeb%5CGEDWEB%5Cdocs%5Coutput-202502080757123456.xml&
//
//btnEnviar=Enviar
//
void CRequestData::parseQueryString()
{
	/* FORM */

	int pos = 0;
	//Documento
	parseParam(this->m_txtDocumentoRevisaoId, BIGSTRSZ, pos++);
	parseParam(this->m_txtDocumentoId, BIGSTRSZ, pos++);
	parseParam(this->m_txtDocumentoNome, BIGSTRSZ, pos++);
	parseParam(this->m_txtDocumentoNomeArquivo, BIGSTRSZ, pos++);
	parseParam(this->m_txtDocumentoDescricao, BIGSTRSZ, pos++);
	parseParam(this->m_txtDocumentoData, BIGSTRSZ, pos++);
	parseParam(this->m_txtDocumentoRevisaoData, BIGSTRSZ, pos++);
	//Autor
	parseParam(this->m_txtAutorId, BIGSTRSZ, pos++);
	parseParam(this->m_txtAutorNome, BIGSTRSZ, pos++);
	parseParam(this->m_txtAutorFormacao, BIGSTRSZ, pos++);
	parseParam(this->m_txtAutorEmail, BIGSTRSZ, pos++);
	parseParam(this->m_txtAutorTelefone, BIGSTRSZ, pos++);
	//Usuario
	parseParam(this->m_txtUsuarioId, BIGSTRSZ, pos++);
	parseParam(this->m_txtUsuarioNome, BIGSTRSZ, pos++);
	parseParam(this->m_txtUsuarioEmail, BIGSTRSZ, pos++);
	parseParam(this->m_txtUsuarioTelefone, BIGSTRSZ, pos++);
	//ArquivoDados
	parseParam(this->m_txtArquivoDados, BIGSTRSZ, pos++);
	//ArquivoSaida
	parseParam(this->m_txtArquivoSaida, BIGSTRSZ, pos++);
	//Enviar
	parseParam(this->m_btnEnviar, BIGSTRSZ, pos++);
}

/* Getters/Setters */

TCHAR* CRequestData::getQueryString() {
	return m_queryString;
}

TCHAR* CRequestData::getDocumentoRevisaoId() {
	return m_txtDocumentoRevisaoId;
}

TCHAR* CRequestData::getDocumentoId() {
	return m_txtDocumentoId;
}

TCHAR* CRequestData::getDocumentoNome() {
	return m_txtDocumentoNome;
}

TCHAR* CRequestData::getDocumentoNomeArquivo() {
	return m_txtDocumentoNomeArquivo;
}

TCHAR* CRequestData::getDocumentoDescricao() {
	return m_txtDocumentoDescricao;
}

TCHAR* CRequestData::getDocumentoData() {
	return m_txtDocumentoData;
}

TCHAR* CRequestData::getDocumentoRevisaoData() {
	return m_txtDocumentoRevisaoData;
}

TCHAR* CRequestData::getAutorId() {
	return m_txtAutorId;
}

TCHAR* CRequestData::getAutorNome() {
	return m_txtAutorNome;
}

TCHAR* CRequestData::getAutorFormacao() {
	return m_txtAutorFormacao;
}

TCHAR* CRequestData::getAutorEmail() {
	return m_txtAutorEmail;
}

TCHAR* CRequestData::getAutorTelefone() {
	return m_txtAutorTelefone;
}

TCHAR* CRequestData::getUsuarioId() {
	return m_txtUsuarioId;
}

TCHAR* CRequestData::getUsuarioNome() {
	return m_txtUsuarioNome;
}

TCHAR* CRequestData::getUsuarioEmail() {
	return m_txtUsuarioEmail;
}

TCHAR* CRequestData::getUsuarioTelefone() {
	return m_txtUsuarioTelefone;
}

TCHAR* CRequestData::getArquivoDados() {
	return m_txtArquivoDados;
}

TCHAR* CRequestData::getArquivoSaida() {
	return m_txtArquivoSaida;
}
