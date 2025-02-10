/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* Ctx.cpp
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

#include"stdafx.h"
#include "All.h"

CCtx::CCtx(TCHAR* homeDir)
{
	this->init(homeDir);
}

CCtx::~CCtx()
{
	/* nothing todo! */
}

void CCtx::init(TCHAR* homeDir)
{
	strNCpyUtil(m_homeDir, homeDir, BIGSTRSZ);

	strNCpyUtil(m_binDir, m_homeDir, BIGSTRSZ);
	strNCatUtil(m_binDir, CTX_BINDIR, BIGSTRSZ);

	strNCpyUtil(m_confDir, m_homeDir, BIGSTRSZ);
	strNCatUtil(m_confDir, CTX_CONFDIR, BIGSTRSZ);

	strNCpyUtil(m_dataDir, m_homeDir, BIGSTRSZ);
	strNCatUtil(m_dataDir, CTX_DATADIR, BIGSTRSZ);

	strNCpyUtil(m_docsDir, m_homeDir, BIGSTRSZ);
	strNCatUtil(m_docsDir, CTX_DOCSDIR, BIGSTRSZ);

	strNCpyUtil(m_repositorioDir, m_homeDir, BIGSTRSZ);
	strNCatUtil(m_repositorioDir, CTX_REPOSITORIODIR, BIGSTRSZ);

	strNCpyUtil(m_templateDir, m_homeDir, BIGSTRSZ);
	strNCatUtil(m_templateDir, CTX_TEMPLATESDIR, BIGSTRSZ);

	strNCpyUtil(m_outputDir, m_homeDir, BIGSTRSZ);
	strNCatUtil(m_outputDir, CTX_OUTPUTDIR, BIGSTRSZ);

	strNCpyUtil(m_confFile, m_confDir, BIGSTRSZ);
	strNCatUtil(m_confFile, CTX_CONFFILE, BIGSTRSZ);

	strNCpyUtil(m_confFileDefault, m_confDir, BIGSTRSZ);
	strNCatUtil(m_confFileDefault, CTX_CONFFILEDEFAULT, BIGSTRSZ);

	strNCpyUtil(m_templateFile, m_templateDir, BIGSTRSZ);
	strNCatUtil(m_templateFile, CTX_TEMPLATEFILE, BIGSTRSZ);
}

void CCtx::debug(int debugLevel)
{
	if (debugLevel != DEBUG_LEVEL) return;

	wprintf(
		_T("HomeDir:%s\nBinDir:%s\nConfDir:%s\nDataDir:%s\nDocsDir:%s\nRepositorioDir:%s\nTemplateDir:%s\nOutputDir:%s\nConfFile:%s\nConfFileDefault:%s\nTemplateFile:%s\n"),
		m_homeDir,
		m_binDir,
		m_confDir,
		m_dataDir,
		m_docsDir,
		m_repositorioDir,
		m_templateDir,
		m_outputDir,
		m_confFile,
		m_confFileDefault,
		m_templateFile);
}

/* Getters/Setters */

TCHAR* CCtx::getHomeDir()
{
	return m_homeDir;
}

TCHAR* CCtx::getBinDir()
{
	return m_binDir;
}

TCHAR* CCtx::getConfDir()
{
	return m_confDir;
}

TCHAR* CCtx::getDataDir()
{
	return m_dataDir;
}

TCHAR* CCtx::getDocsDir()
{
	return m_docsDir;
}

TCHAR* CCtx::getRepositorioDir()
{
	return m_repositorioDir;
}

TCHAR* CCtx::getTemplateDir()
{
	return m_templateDir;
}

TCHAR* CCtx::getOutputDir()
{
	return m_outputDir;
}

TCHAR* CCtx::getConfFile()
{
	return m_confFile;
}

TCHAR* CCtx::getConfFileDefault()
{
	return m_confFileDefault;
}

TCHAR* CCtx::getTemplateFile()
{
	return m_templateFile;
}
