/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* Error.cpp
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
#include"all.h"

void warnMsg(int debugLevel, const TCHAR* className, const TCHAR* methodName, const TCHAR* errorMessage)
{
	if (debugLevel != DEBUG_LEVEL) return;

	printf("WARN(%s_%s): %s\n", className, methodName, errorMessage);
}

void warnMsgAndWaitForKey(int debugLevel, const TCHAR* className, const TCHAR* methodName, const TCHAR* errorMessage)
{
	if (debugLevel != DEBUG_LEVEL) return;

	printf("WARN(%s_%s): %s\n", className, methodName, errorMessage);

	printf("\n\nPress [ENTER] to continue.");
	while (getchar() != K_CR) {
		printf("\nPress [ENTER] to continue.");
	}
}

void warnMsgIfNull(int debugLevel, const TCHAR* className, const TCHAR* methodName, const TCHAR* errorMessage, void* data)
{
	if (debugLevel != DEBUG_LEVEL) return;

	if (data == NULL) {
		warnMsg(debugLevel, className, methodName, errorMessage);
	}
}

void errMsg(const TCHAR* className, const TCHAR* methodName, const TCHAR* errorMessage)
{
	printf("ERR(%s_%s): %s\n", className, methodName, errorMessage);
	exit(1);
}

void errMsgIfNull(const TCHAR* className, const TCHAR* methodName, const TCHAR* errorMessage, void* data)
{
	if (data == NULL) {
		errMsg(className, methodName, errorMessage);
	}
}
