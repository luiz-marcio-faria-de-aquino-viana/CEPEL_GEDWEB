/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* Util.cpp
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

/* STRING UTILS
*/

int strIsEmptyUtil(TCHAR* src)
{
	if ((*src) == '\0')
		return(DBTRUE);
	return(DBFALSE);
}

TCHAR* strSetEmptyUtil(TCHAR* src)
{
	(*src) = '\0';
	return(src);
}

int strLenUtil(TCHAR* src, int n)
{
	TCHAR* p_src = src;
	int n_src = 0;
	while (n_src < n) {
		if ((*p_src) == '\0') break;
		p_src++;
		n_src += 1;
	}
	return(n_src);
}

int strCharCountUtil(TCHAR* src, int n, char c)
{
	TCHAR* p = src;
	int cnt = 0;
	for (int i = 0; i < n; i++) {
		if ((*p) == '\0') break;
		if ((*p) == c)
			cnt += 1;
		p++;
	}
	return cnt;
}

TCHAR* strPieceUtil(TCHAR* inPath, int inPathSz, TCHAR* outPath, int outPathSz, TCHAR c, int n)
{
	TCHAR* p_in = inPath;
	TCHAR* p_out = outPath;

	int n_in = 0;
	int n_last = n;

	if (n_in < n_last) {
		int i = 0;
		for (; i < inPathSz; i++) {
			if ((*p_in) == _T('\0')) break;
			if ((*p_in) == c) {
				n_in += 1;
				if (n_in >= n_last) {
					p_in++;
					break;
				}
			}
			p_in++;
		}
	}

	if (n_in >= n_last) {
		int j = 0;
		for (; j < outPathSz; j++) {
			if ((*p_in) == _T('\0')) break;
			if ((*p_in) == c) break;
			(*p_out) = (*p_in);
			p_out++;
			p_in++;
		}
		(*p_out) = _T('\0');
		outPath[outPathSz - 1] = _T('\0');
	}
	return outPath;
}

TCHAR* strNCpyCaseUtil(TCHAR* dst, TCHAR* src, int n, int caseSensitive)
{
	TCHAR* p_src = src;
	TCHAR* p_dst = dst;

	int n_dst = 0;
	while (n_dst < n)
	{
		if (caseSensitive == DEF_CASESENSITIVE_TOUPPER)
			(*p_dst) = _totupper(*p_src);
		else if (caseSensitive == DEF_CASESENSITIVE_TOLOWER)
			(*p_dst) = _totlower(*p_src);
		else
			(*p_dst) = (*p_src);

		if ((*p_src) == '\0') break;

		p_src++;
		p_dst++;
		n_dst += 1;
	}
	dst[n - 1] = '\0';
	return(dst);
}

TCHAR* strNCpyUtil(TCHAR* dst, TCHAR* src, int n)
{
	TCHAR* p_src = src;
	TCHAR* p_dst = dst;

	int n_dst = 0;
	while (n_dst < n)
	{
		(*p_dst) = (*p_src);

		if ((*p_src) == '\0') break;

		p_src++;
		p_dst++;
		n_dst += 1;
	}
	dst[n - 1] = '\0';
	return(dst);
}

TCHAR* strNCatUtil(TCHAR* dst, TCHAR* src, int n)
{
	TCHAR* p_src = src;
	TCHAR* p_dst = dst;

	int n_dst = 0;
	while (n_dst < n)
	{
		if ((*p_dst) == '\0') break;

		p_dst++;
		n_dst += 1;
	}

	while (n_dst < n)
	{
		(*p_dst) = (*p_src);

		if ((*p_src) == '\0') break;

		p_src++;
		p_dst++;
		n_dst += 1;
	}
	dst[n - 1] = '\0';
	return(dst);
}

int strNCmpUtil(TCHAR* src1, TCHAR* src2, int n)          // 0=Iguais / -1=Se src1 antecede src2 / 1=Se src1 sucede src2
{
	TCHAR* p_src1 = src1;
	TCHAR* p_src2 = src2;

	int n_src = 0;
	while ((n_src < (n - 1)) && ((*p_src1) != '\0') && ((*p_src2) != '\0'))
	{
		if ((*p_src1) < (*p_src2))
			return -1;

		if ((*p_src1) > (*p_src2))
			return 1;

		p_src1++;
		p_src2++;

		n_src += 1;
	}

	if ((*p_src1) < (*p_src2))
		return -1;

	if ((*p_src1) > (*p_src2))
		return 1;

	return 0;
}

int strNCmpCaseUtil(TCHAR* src1, TCHAR* src2, int n, int caseSensitive)           // 0=Iguais / -1=Se src1 antecede src2 / 1=Se src1 sucede src2
{
	TCHAR* p_src1 = src1;
	TCHAR* p_src2 = src2;

	int n_src = 0;
	while ((n_src < (n - 1)) && ((*p_src1) != '\0') && ((*p_src2) != '\0'))
	{
		int c_src1 = (*p_src1);
		int c_src2 = (*p_src2);

		if (c_src1 == DEF_CASESENSITIVE_TOUPPER) {
			c_src1 = _totupper(*p_src1);
			c_src2 = _totupper(*p_src2);
		}
		else if (c_src2 == DEF_CASESENSITIVE_TOLOWER) {
			c_src1 = _totlower(*p_src1);
			c_src2 = _totlower(*p_src2);
		}

		if (c_src1 < c_src2)
			return -1;

		if (c_src1 > c_src2)
			return 1;

		p_src1++;
		p_src2++;

		n_src += 1;
	}

	int c_src1 = (*p_src1);
	int c_src2 = (*p_src2);

	if (c_src1 == DEF_CASESENSITIVE_TOUPPER) {
		c_src1 = _totupper(*p_src1);
		c_src2 = _totupper(*p_src2);
	}
	else if (c_src2 == DEF_CASESENSITIVE_TOLOWER) {
		c_src1 = _totlower(*p_src1);
		c_src2 = _totlower(*p_src2);
	}

	if (c_src1 < c_src2)
		return -1;

	if (c_src1 > c_src2)
		return 1;

	return 0;
}

TCHAR* strRemoveEolUtil(TCHAR* src, int n)
{
	TCHAR* p_src = src;
	int n_src = 0;
	while ((n_src < (n - 1)) && ((*p_src) != '\0'))
	{
		if (((*p_src) == '\r') || ((*p_src) == '\n'))
			(*p_src) = '\0';
		p_src++;

		n_src += 1;
	}
	return 0;
}

TCHAR* strRemoveCharUtil(TCHAR* dst, char c, int n)
{
	TCHAR* p_src = &dst[0];
	TCHAR* p_dst = &dst[0];
	for (int i = 0; i < n; i++)
	{
		if ((*p_src) != c) {
			(*p_dst) = (*p_src);
			p_dst++;
		}
		p_src++;
	}
	return dst;
}

TCHAR* strReplaceUtil(TCHAR* dst, TCHAR c_src, TCHAR c_dst, int n)
{
	TCHAR* p_dst = &dst[0];
	for (int i = 0; i < n; i++)
	{
		if ((*p_dst) == c_src)
			(*p_dst) = c_dst;
		p_dst++;
	}
	return dst;
}

TCHAR* strFillCharUtil(TCHAR* dst, TCHAR c, int n)
{
	TCHAR* p = &dst[0];
	for (int i = 0; i < n; i++)
	{
		(*p) = ' ';
		p++;
	}
	(*p) = '\0';

	return p;
}

TCHAR* strFillUtil(TCHAR* dst, TCHAR* src, int n)
{
	int src_sz = strLenUtil(src, n);
	int min_sz = MIN(src_sz, n - 1);

	int prefix_sz = min_sz / 2;

	TCHAR* p = &dst[0];
	strFillCharUtil(p, ' ', prefix_sz);

	strNCpyUtil(p, src, src_sz);

	int sufix_pos = prefix_sz + src_sz;
	int sufix_sz = n - sufix_pos;

	p = &dst[sufix_pos];
	strFillCharUtil(p, ' ', sufix_sz);

	return dst;
}

TCHAR* strFillLeftUtil(TCHAR* dst, TCHAR* src, int n)
{
	strNCpyUtil(dst, src, n);
	int dst_sz = strLenUtil(dst, n);

	int min_sz = MIN(dst_sz, n - 1);

	TCHAR* p = &dst[min_sz];
	strFillCharUtil(p, ' ', n - 1);
	(*p) = '\0';

	return dst;
}

TCHAR* strFillRightUtil(TCHAR* dst, TCHAR* src, int n)
{
	int src_sz = strLenUtil(src, n);

	int max_sz = n - src_sz;

	TCHAR* p = &dst[0];
	strFillCharUtil(p, ' ', max_sz);

	p = &dst[max_sz];
	strNCpyUtil(p, src, src_sz);
	dst[n - 1] = '\0';

	return dst;
}

/* LOAD_IMAGE
*/

int loadImageFile(TCHAR* fileName, byte* data, int* dataSz)
{
	FILE* fp = NULL;
	
	_wfopen_s(&fp, fileName, FILMODE_READ);
	if (fp == NULL) return RSERR;

	size_t numRead = fread(data, sizeof(char), (*dataSz), fp);
	if (numRead == 0) return RSERR;

	(*dataSz) = numRead;
	return RSOK;
}

/* MEM UTILS
*/

int memIsNullUtil(byte* src, int n)
{
	for (int i = 0; i < n; i++)
	{
		if ((*src) != 0)
			return(RSERR);
		src++;
	}
	return(RSOK);
}

byte* memSetNullUtil(byte* src, int n)
{
	bigstr_t errmsg;

	swprintf_s(errmsg, (TCHAR*)"\nMemSetNullUtil(src=%ld, n=%d)", (long)src, n);
	warnMsg(DEBUG_LEVEL01, __UTIL_H, (TCHAR*)"memSetNullUtil()", errmsg);

	byte* p = src;
	for (int i = 0; i < n; i++)
	{
		(*p) = 0;
		p++;
	}
	return(src);
}

byte* memNCpyUtil(byte* dst, byte* src, int n)
{
	bigstr_t errmsg;

	swprintf_s(errmsg, (TCHAR*)"\nMemNCpyUtil(dst=%ld, src=%ld, n=%d)", (long)dst, (long)src, n);
	warnMsg(DEBUG_LEVEL01, __UTIL_H, (TCHAR*)"memNCpyUtil()", errmsg);

	byte* p_src = src;
	byte* p_dst = dst;

	for (int i = 0; i < n; i++)
	{
		(*p_dst) = (*p_src);

		p_src++;
		p_dst++;
	}
	return(dst);
}

byte* memNCatUtil(byte* dst, byte* src, int n_i, int n)
{
	byte* p_src = src;
	byte* p_dst = dst;

	for (int i = 0; i < n_i; i++)
		p_dst++;

	int n_sz = n - n_i + 1;
	for (int i = n_i; i < n_sz; i++)
	{
		(*p_dst) = (*p_src);

		p_src++;
		p_dst++;
	}
	return(dst);
}

int memNCmpUtil(byte* src1, byte* src2, int n)      // 0=Iguais / -1=Se src1 antecede src2 / 1=Se src1 sucede src2
{
	byte* p_src1 = src1;
	byte* p_src2 = src2;

	for (int i = 0; i < n; i++)
	{
		if ((*p_src1) < (*p_src2))
			return -1;

		if ((*p_src1) > (*p_src2))
			return 1;

		p_src1++;
		p_src2++;
	}

	return 0;
}

/* FILE NAME AND PATH OPERATIONS
*/

TCHAR* getFileName(TCHAR* inFileName, int inFileNameSz, TCHAR* outFileName, int outFileNameSz)
{
	//int path_len = getPathLen(inFileName, inFileNameSz);
	//getPathAt(inFileName, inFileNameSz, outFileName, outFileNameSz, path_len);
	return outFileName;
}

TCHAR* getFileNameWithoutExt(TCHAR* inFileName, int inFileNameSz, TCHAR* outFileName, int outFileNameSz)
{
	bigstr_t strTmp;
	int n = strCharCountUtil(inFileName, inFileNameSz, '.');
	strPieceUtil(inFileName, inFileNameSz, strTmp, BIGSTRSZ, '.', n - 1);
	getFileName(inFileName, inFileNameSz, outFileName, outFileNameSz);
	return outFileName;
}

TCHAR* getFileExt(TCHAR* inFileName, int inFileNameSz, TCHAR* outFileExt, int outFileExtSz)
{
	int n = strCharCountUtil(inFileName, inFileNameSz, '.');
	strPieceUtil(inFileName, inFileNameSz, outFileExt, outFileExtSz, '.', n);
	return outFileExt;
}

int getPathLen(TCHAR* inPath, int inPathSz)
{
	int n = strCharCountUtil(inPath, inPathSz, '/');
	return n;
}

TCHAR* getPathAt(TCHAR* inPath, int inPathSz, TCHAR* outPath, int outPathSz, int n)
{
	strPieceUtil(inPath, inPathSz, outPath, outPathSz, '/', n);
	return outPath;
}

/* FILE OPERATIONS
*/

int existFileUtil(const TCHAR* fileName)
{
	FILE* f = NULL;
	
	_wfopen_s(&f, fileName, FILMODE_READ);
	if (f == NULL)
		return(RSERR);
	return(RSOK);
}

int openFileUtil(FILE** f, const TCHAR* fileName, const TCHAR* fileMode, long bSeekBegin)
{
	int rscode = RSERR;

	(*f) = NULL;

	_wfopen_s(f, fileName, fileMode);
	if ((*f) == NULL) {
		warnMsg(DEBUG_LEVEL01, __UTIL_H, (TCHAR*)"openFile()", (TCHAR*)ERR_CANTOPENFILE);
		return(RSERR);
	}

	if (bSeekBegin == DBTRUE) {
		if (fseek((*f), 0L, SEEK_SET) != -1)
			rscode = RSOK;
	}
	else {
		rscode = RSOK;
	}
	return(rscode);
}

int openFileUtilMT(FILE** f, const TCHAR* fileName, const TCHAR* fileMode, long bSeekBegin)
{
	int rscode = RSERR;

	int numberOfRetry = 0;

	(*f) = NULL;
	while ((*f) == NULL) {
		_wfopen_s(f, fileName, fileMode);
		if ((*f) == NULL) {
			numberOfRetry += 1;

			if (numberOfRetry >= MAX_NUMBER_OF_FILEOPEN_RETRY) {
				warnMsg(DEBUG_LEVEL01, __UTIL_H, (TCHAR*)"openFile()", (TCHAR*)ERR_CANTOPENFILE);
				return(RSERR);
			}

			Sleep(MAX_TIMEOUT_BETWEN_FILEOPEN_RETRY);
		}
	}

	if (bSeekBegin == DBTRUE) {
		if (fseek((*f), 0L, SEEK_SET) != -1)
			rscode = RSOK;
	}
	else {
		rscode = RSOK;
	}
	return(rscode);
}

int writeFileUtil(const TCHAR* fileName, byte* data, long datasz)
{
	FILE* f = NULL;

	int rscode = openFileUtil(&f, fileName, FILMODE_WRITE, DBTRUE);
	if (rscode == RSOK) {
		fwrite(data, sizeof(byte), datasz, f);
		fclose(f);
	}
	return rscode;
}

int readFileUtil(const TCHAR* fileName, byte** data, long* datasz)
{
	FILE* f = NULL;
	long numread;

	//printf("\nFileName: %s", fileName);
	int rscode = openFileUtil(&f, fileName, FILMODE_READ, DBTRUE);
	if (rscode == RSOK) {

		//printf("\nFileName: %s... OPENED_FOR_READ!", fileName);
		rscode = FILE_ACCESS_RESULT(fseek(f, 0L, SEEK_END));
		if (rscode == RSOK) {
			//printf("\nFileName: %s... SEEK_TO_END!", fileName);
			(*datasz) = ftell(f);

			//printf("\nFileName: %s... Size: %ld", fileName, (*datasz));
			(*data) = (byte*)allocData(*datasz);
			if ((*data) != NULL) {
				//printf("\nFileName: %s... Size: %ld... DATA_ALLOCATED!", fileName, (*datasz));
				rscode = FILE_ACCESS_RESULT(fseek(f, 0L, SEEK_SET));
				if (rscode == RSOK) {
					//printf("\nFileName: %s... Size: %ld... SEEK_TO_BEGIN!", fileName, (*datasz));

					long pos = 0;
					byte* p = &(*data)[pos];
					while ((numread = fread(p, sizeof(byte), BUFSZ, f)) > 0) {
						pos += numread;
						p = &(*data)[pos];
					}
					//printf("\nFileName: %s... Size: %ld... CurrPos: %ld... NumRead: %ld... EOF! ", fileName, (*datasz), pos, numread);
				}
			}
		}
		fclose(f);
	}
	return rscode;
}

long sizeDataFileUtil(const TCHAR* fileName)
{
	FILE* f = NULL;
	bigstr_t sbuf;

	_wfopen_s(&f, fileName, FILMODE_READ_ASCII);
	if (f == NULL) return RSERR;

	int numbytes = 0;
	while (fgets((char*)sbuf, BIGSTRSZ - 1, f) != 0) {
		sbuf[BIGSTRSZ - 1] = '\0';
		numbytes += BIGSTRSZ;
	}
	fclose(f);

	return numbytes;
}

int readDataFileUtil(const TCHAR* fileName, TCHAR* data, long datasz)
{
	FILE* f = NULL;
	bigstr_t sbuf;

	errno_t err;

	err = _wfopen_s(&f, fileName, FILMODE_READ_ASCII);
	if (err != 0) return RSERR;

	long pos = 0;
	while(fgetws(sbuf, BIGSTRSZ - 1, f) != 0) {
		sbuf[BIGSTRSZ - 1] = _T('\0');

		int sz = strLenUtil(sbuf, BIGSTRSZ);
		if (sz > 0) {
			TCHAR* p = & data[pos];
			strNCpyUtil(p, sbuf, BIGSTRSZ);
			pos += sz;
		}
	}
	fclose(f);

	return RSOK;
}

/* ALLOC DATA OPERATIONS
*/

void* allocData(int dataSize)
{
	void* data = malloc(dataSize);
	errMsgIfNull(__UTIL_H, (TCHAR*)"allocData()", (TCHAR*)ERR_CANTALLOCATEMEMORY, data);
	return data;
}

void* allocDataArray(int dataSize, int numItens)
{
	int size = dataSize * numItens;
	void* data = malloc(size);
	errMsgIfNull(__UTIL_H, (TCHAR*)"allocDataArray()", (TCHAR*)ERR_CANTALLOCATEMEMORY, data);
	return data;
}

void freeData(void* data)
{
	if (data != NULL) {
		free(data);
		data = NULL;
	}
}

void freeDataArray(void* data)
{
	if (data != NULL) {
		free(data);
		data = NULL;
	}
}

/* HASH OPERATIONS
*/

ULng getHash(TCHAR* p)
{
	ULng hashVal = 0;

	ULng maxVal = 1000009;

	ULng q = 31;
	ULng q_memb = 1;

	while ((*p) != _T('\0'))
	{
		int c = (*p) - '@' + 1;

		hashVal = hashVal + ((c * q_memb) % maxVal);
		q_memb = (q_memb * q) % maxVal;
		p++;
	}
	return hashVal;
}

/* TIME OPERATIONS
*/

void getLocalTimeStr(TCHAR* local_time_str)
{
	//time_t t = time(NULL);

	//struct tm local_time = *localtime(&t);

	//sprintf(local_time_str,
		//"%04d-%02d-%02d_%02d:%02d:%02d",
		//local_time.tm_year + 1900,
		//local_time.tm_mon + 1,
		//local_time.tm_mday,
		//local_time.tm_hour,
		//local_time.tm_min,
		//local_time.tm_sec);
}

long getCurrentTimestamp()
{
	//struct timeval tv;
	//gettimeofday(&tv, NULL);

	//long result = (tv.tv_sec * 1000000) + tv.tv_usec;
	long result = -1;
	return result;
}

/* GENERATE RANDOM OID
*/

long generateRandomOid()
{
	long rndVal = rand() % 1000;

	long currTimestamp = getCurrentTimestamp();
	currTimestamp = (currTimestamp * 1000) + rndVal;
	return currTimestamp;
}

long generateRandomVal()
{
	int seed = (int)getCurrentTimestamp();
	srand(seed);

	long rndVal = rand() % 1000000;
	return rndVal;
}

long generateRandomVal(long maxVal)
{
	int seed = (int)getCurrentTimestamp();
	srand(seed);

	long rndVal = rand() % maxVal;
	return rndVal;
}

/* ENCODE/DECODE (HEX)
*/

int encodeHex(byte* in_data, long in_datasz, char** out_data, long* out_datalen)
{
	(*out_datalen) = (2 * in_datasz) + 1;
	(*out_data) = (char*)allocData((*out_datalen));

	byte* p_in = in_data;
	char* p_out = (*out_data);

	for (int i = 0; i < in_datasz; i++)
	{
		(*p_out) = ((*p_in) / 16) + 64;
		p_out++;

		(*p_out) = ((*p_in) % 16) + 64;
		p_out++;

		p_in++;
	}
	(*p_out) = '\0';

	return RSOK;
}

int decodeHex(char* in_data, long in_datalen, byte** out_data, long* out_datasz)
{
	long in_datasz = in_datalen - 1;

	(*out_datasz) = in_datasz / 2;
	if ((in_datasz % 2) != 0)
		(*out_datasz) += 1;

	(*out_data) = (byte*)allocData((*out_datasz));

	char* p_in = in_data;
	byte* p_out = (*out_data);

	for (int i = 0; i < in_datasz; i += 2)
	{
		byte hb = ((*p_in) - 64) * 16;
		p_in++;

		byte lb = ((*p_in) - 64);
		p_in++;

		(*p_out) = hb + lb;
		p_out++;
	}

	return RSOK;
}

/* WAIT MESSAGE */

void showMessage(const TCHAR* str, long bWaitKey)
{
	if ((DEBUG_LEVEL == DEBUG_LEVEL00) || (DEBUG_LEVEL == DEBUG_LEVEL99)) return;

	if (bWaitKey == DBTRUE) {
		wprintf((TCHAR*)"\n%s... press [ENTER] to continue.", str);
		while (getchar() != K_CR) {
			wprintf((TCHAR*)"\n%s... press [ENTER] to continue.", str);
		}
	}
	else {
		wprintf((TCHAR*)"\n%s... ", str);
	}
}

void showMessageAndWaitForKey(const TCHAR* str)
{
	wprintf((TCHAR*)"\n%s... press [ENTER] to continue.", str);
	while (getchar() != K_CR) {
		wprintf((TCHAR*)"\n%s... press [ENTER] to continue.", str);
	}
}
