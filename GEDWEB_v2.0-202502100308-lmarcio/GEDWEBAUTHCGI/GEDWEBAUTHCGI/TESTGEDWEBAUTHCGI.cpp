/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* TESTGEDWEBAUTHCGI.cpp
* Autor:
*   Luiz Marcio Faria de Aquino Viana, Pos-D.Sc. - Engenheiro, 08/02/2025
*   Unidade: Universidade do Estado do Rio de Janeiro
*   Curso: Engenharia Eletrica, Enfase em Engenharia de Sistemas e Computação
*   Unico Socio e Administrador da Empresa - Desde: 02/08/2000
*
* Revisoes: ...
*
*/

#include"stdafx.h"
#include"All.h"

int testApp(int argc, TCHAR* argv[])
{
	bigstr_t str;
	strNCpyUtil(str, _T("txtDocumentoRevisaoId=2100010&txtDocumentoId=1100001&txtDocumentoNome=GALAX_-_FUNDAMENTOS_DE_COMPUTADORES_DIGITAIS&txtDocumentoNomeArquivo=GALAX.MAC&txtDocumentoDescricao=Jogo_Desenvolvido_100_perc_em_Assembler_Z80_para_a_Disciplina_de_Fundamentos_de_Computadores_Digitais_do_Professor_Orlando_UERJ&txtDocumentoData=20250207_20_40&txtDocumentoRevisaoData=20250207_20_58&txtAutorId=9100001&txtAutorNome=Luiz_Marcio_Faria_de_Aquino_Viana&txtAutorFormacao=Engenheiro_Eletricista_com_Enfase_em_Engenharia_de_Sistemas_e_Computacao&txtAutorEmail=luiz.marcio.viana_at_gmail.com&txtAutorTelefone=021-999837207&txtUsuarioId=8100001&txtUsuarioNome=Luiz_Marcio_Faria_de_Aquino_Viana&txtUsuarioEmail=luiz.marcio.viana_at_gmail.com&txtUsuarioTelefone=021-999837207&txtArquivoDados=2100010-GEDWEB-GALAX_MAC.dat&txtArquivoSaida=output-202502080757123456.xml&btnEnviar=Enviar"), BIGSTRSZ);

	TCHAR* ptrHomeDir;
	size_t szPtrHomeDir;

	CCtx* ptrCtx = NULL;

	_wdupenv_s(&ptrHomeDir, &szPtrHomeDir, APP_HOME);

	if (ptrHomeDir == NULL) {
		ptrCtx = new CCtx(CTX_HOMEDIR);
	}
	else {
		ptrCtx = new CCtx(ptrHomeDir);
	}
	ptrCtx->debug(DEBUG_LEVEL01);

	CRequestData requestData(str);

	wprintf(
		_T("DocumentoRevisaoId=%s\nDocumentoId=%s\nAutorId=%s\nUsuarioId=%s\nArquivoDados=%s\nArquivoSaida=%s\n"),
		requestData.getDocumentoRevisaoId(),
		requestData.getDocumentoId(),
		requestData.getAutorId(),
		requestData.getUsuarioId(),
		requestData.getArquivoDados(),
		requestData.getArquivoSaida());

	bigstr_t strArquivoDados;
	strNCpyUtil(strArquivoDados, _T("C:\\9998-CEPEL\\001-GEDWEB\\Repositorio\\"), BIGSTRSZ);
	strNCatUtil(strArquivoDados, requestData.getArquivoDados(), BIGSTRSZ);

	wprintf(
		_T("ArquivoDados=%s\n"),
		strArquivoDados);

	long szArquivoDados = sizeDataFileUtil(strArquivoDados);
	wprintf(
		_T("SzArquivoDados=%ld\n"),
		szArquivoDados);

	long szPtrData = szArquivoDados / sizeof(TCHAR);
	wprintf(
		_T("SzPtrData=%ld\n"),
		szPtrData);

	TCHAR* ptrData = (TCHAR*)allocData(szArquivoDados + 1);
	if (ptrData != NULL) {
		int rscode = readDataFileUtil(strArquivoDados, ptrData, szPtrData);
		if (rscode == RSOK) {
			bigstr_t strModeloDocumento;
			strNCpyUtil(strModeloDocumento, _T("C:\\9998-CEPEL\\001-GEDWEB\\Templates\\"), BIGSTRSZ);
			strNCatUtil(strModeloDocumento, _T("202502081407-GEDWEB-Modelo_Documento.tpl"), BIGSTRSZ);

			wprintf(
				_T("ModeloDocumento=%s\n"),
				strModeloDocumento);

			long szModeloDocumento = sizeDataFileUtil(strModeloDocumento);
			wprintf(
				_T("SzModeloDocumento=%ld\n"),
				szModeloDocumento);

			long szPtrModeloDocumento = szModeloDocumento / sizeof(TCHAR);
			wprintf(
				_T("SzPtrModeloDocumento=%ld\n"),
				szPtrModeloDocumento);

			TCHAR* ptrModeloDocumento = (TCHAR*)allocData(szModeloDocumento + 1);
			if (ptrModeloDocumento != NULL) {
				int rscode = readDataFileUtil(strModeloDocumento, ptrModeloDocumento, szPtrModeloDocumento);
				if (rscode == RSOK) {
					ULng hash = getHash(ptrData);

					bigstr_t outputFile;
					strNCpyUtil(outputFile, ptrCtx->getOutputDir(), BIGSTRSZ);
					strNCatUtil(outputFile, requestData.getArquivoSaida(), BIGSTRSZ);

					FILE* f = NULL;
					_wfopen_s(&f, outputFile, FILMODE_WRITE_ASCII);
					if (f != 0) {
						fwprintf(f, _T("<? xml version='1.0' ?>\n"));
						fwprintf(f, _T("<CEPEL_GEDWEB>\n"));
						fwprintf(f, _T("<CEPEL_DocumentoCompleto>"));
						fwprintf(
							f, 
							ptrModeloDocumento,
							requestData.getDocumentoRevisaoId(),
							requestData.getDocumentoId(),
							requestData.getDocumentoNome(),
							requestData.getDocumentoNomeArquivo(),
							requestData.getDocumentoDescricao(),
							requestData.getDocumentoData(),
							requestData.getDocumentoRevisaoData(),
							requestData.getAutorId(),
							requestData.getAutorNome(),
							requestData.getAutorFormacao(),
							requestData.getAutorEmail(),
							requestData.getAutorTelefone(),
							requestData.getUsuarioId(),
							requestData.getUsuarioNome(),
							requestData.getUsuarioEmail(),
							requestData.getUsuarioTelefone(),
							ptrData);
						fwprintf(f, _T("</CEPEL_DocumentoCompleto>\n"));
						fwprintf(f, _T("<CEPEL_Signature><![CDATA[%uld]]></CEPEL_Signature>\n"), hash);
						fwprintf(f, _T("</CEPEL_GEDWEB>\n"));

						fclose(f);
					}

					freeData(ptrModeloDocumento);
				}
			}
		}
		freeData(ptrData);
	}

	return 0;
}
