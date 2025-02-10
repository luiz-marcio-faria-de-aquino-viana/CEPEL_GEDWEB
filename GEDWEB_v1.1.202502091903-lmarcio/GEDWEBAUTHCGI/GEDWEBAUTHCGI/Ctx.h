/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* Ctx.h
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

#ifndef __CTX_H
#define __CTX_H								"__CTX_H"

class CCtx
{
private:
	bigstr_t m_homeDir;
	//
	bigstr_t m_binDir;
	bigstr_t m_confDir;
	bigstr_t m_dataDir;
	bigstr_t m_docsDir;
	bigstr_t m_repositorioDir;
	bigstr_t m_templateDir;
	bigstr_t m_outputDir;
	//
	bigstr_t m_confFile;
	bigstr_t m_confFileDefault;
	//
	bigstr_t m_templateFile;

public:

	CCtx(TCHAR* homeDir);
	~CCtx();

	/* Methodes */

	void init(TCHAR* homeDir);

	void debug(int debugLevel);

	/* Getters/Setters */

	TCHAR* getHomeDir();

	TCHAR* getBinDir();

	TCHAR* getConfDir();

	TCHAR* getDataDir();

	TCHAR* getDocsDir();

	TCHAR* getRepositorioDir();

	TCHAR* getTemplateDir();

	TCHAR* getOutputDir();

	TCHAR* getConfFile();

	TCHAR* getConfFileDefault();

	TCHAR* getTemplateFile();

};

#endif
