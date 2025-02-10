/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* GEDWEBAUTHCGI.h
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

#ifndef __GEDWEBAUTHCGI_H
#define __GEDWEBAUTHCGI_H									(TCHAR*)"__GEDWEBAUTHCGI_H"

class CGedWebAuthCGI
{
private:
	CCtx* m_ptrCtx;

	TCHAR* m_ptrHomeDir;
	size_t m_szPtrHomeDir;

	TCHAR* m_ptrRequestMehod;
	size_t m_szPtrRequestMehod;

	TCHAR* m_ptrQueryString;
	size_t m_szPtrQueryString;

	CRequestData* m_ptrRequestData;

	/* Methodes */

	void doOutputHeader();

	void doOutput();

	void doOutputAsAttachment();

public:

	CGedWebAuthCGI();
	~CGedWebAuthCGI();

	/* Methodes */

	void init();

	void execute();

	void terminate();

	/* DEBUG */

	TCHAR* toStr(TCHAR* ptrStr, size_t szPtrStr);

	void debug(int debugLevel);

	/* Getters/Setters */

	CCtx* getCtx();

	TCHAR* getRequestMethod();

	size_t getSzRequestMethod();

	TCHAR* getQueryString();

	size_t getSzQueryString();

};

extern CGedWebAuthCGI* gApp;

int execApp(int argc, TCHAR* argv[]);

int _tmain(int argc, TCHAR* argv[]);

#endif
