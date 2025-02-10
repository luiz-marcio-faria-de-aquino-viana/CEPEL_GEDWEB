/*
* Copyright(C) TLMV Consultoria e Sistemas EIRELI. Todos os direitos reservados.
*
* Util.h
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

#ifndef __UTIL_H
#define __UTIL_H								(TCHAR*)"__UTIL_H"

/* STRING UTILS
*/

int strIsEmptyUtil(TCHAR* src);

TCHAR* strSetEmptyUtil(TCHAR* src);

int strLenUtil(TCHAR* src, int n);

int strCharCountUtil(TCHAR* src, int n, TCHAR c);

TCHAR* strPieceUtil(TCHAR* inPath, int inPathSz, TCHAR* outPath, int outPathSz, TCHAR c, int n);

TCHAR* strNCpyCaseUtil(TCHAR* dst, TCHAR* src, int n, int caseSensitive);

TCHAR* strNCpyUtil(TCHAR* dst, TCHAR* src, int n);

TCHAR* strNCatUtil(TCHAR* dst, TCHAR* src, int n);

int strNCmpUtil(TCHAR* src1, TCHAR* src2, int n);                             // 0=Iguais / -1=Se src1 antecede src2 / 1=Se src1 sucede src2

int strNCmpCaseUtil(TCHAR* src1, TCHAR* src2, int n, int caseSensitive);      // 0=Iguais / -1=Se src1 antecede src2 / 1=Se src1 sucede src2

TCHAR* strRemoveEolUtil(TCHAR* src, int n);

TCHAR* strRemoveCharUtil(TCHAR* dst, TCHAR c, int n);

TCHAR* strReplaceUtil(TCHAR* dst, TCHAR c_src, TCHAR c_dst, int n);

TCHAR* strFillCharUtil(TCHAR* dst, TCHAR* src, TCHAR c, int n);

TCHAR* strFillUtil(TCHAR* dst, TCHAR* src, int n);

TCHAR* strFillLeftUtil(TCHAR* dst, TCHAR* src, int n);

TCHAR* strFillRightUtil(TCHAR* dst, TCHAR* src, int n);

/* LOAD_IMAGE
*/

int loadImageFile(TCHAR* fileName, byte* data, int* dataSz);

/* MEM UTILS
*/

int memIsNullUtil(byte* src, int n);

byte* memSetNullUtil(byte* src, int n);

byte* memNCpyUtil(byte* dst, byte* src, int n);

byte* memNCatUtil(byte* dst, byte* src, int pos, int n);

int memNCmpUtil(byte* src1, byte* src2, int n);     // 0=Iguais / -1=Se src1 antecede src2 / 1=Se src1 sucede src2

/* FILE NAME AND PATH OPERATIONS
*/

TCHAR* getFileName(TCHAR* inFileName, int inFileNameSz, TCHAR* outFileName, int outFileNameSz);

TCHAR* getFileNameWithoutExt(TCHAR* inFileName, int inFileNameSz, TCHAR* outFileName, int outFileNameSz);

TCHAR* getFileExt(TCHAR* inFileName, int inFileNameSz, TCHAR* outFileExt, int outFileExtSz);

int getPathLen(TCHAR* inPath, int inPathSz);

TCHAR* getPathAt(TCHAR* inPath, int inPathSz, TCHAR* outPath, int outPathSz, int n);

/* FILE OPERATIONS
*/

int existFileUtil(const TCHAR* fileName);

int openFileUtil(FILE** f, const TCHAR* fileName, const TCHAR* fileMode, long bSeekBegin);

int writeFileUtil(const TCHAR* fileName, byte* data, long datasz);

int readFileUtil(const TCHAR* fileName, byte** data, long* datasz);

long sizeDataFileUtil(const TCHAR* fileName);

int readDataFileUtil(const TCHAR* fileName, TCHAR* data, long datasz);

/* ALLOC DATA OPERATIONS
*/

void* allocData(int dataSize);

void* allocDataArray(int dataSize, int numItens);

void freeData(void* data);

void freeDataArray(void* data);

/* HASH OPERATIONS
*/

ULng getHash(TCHAR* s);

/* TIME OPERATIONS
*/

void getLocalTimeStr(TCHAR* local_time_str);

long getCurrentTimestamp();

/* GENERATE RANDOM OID
*/

long generateRandomOid();

long generateRandomVal();

long generateRandomVal(long maxVal);

/* ENCODE/DECODE (HEX)
*/

int encodeHex(byte* in_data, long in_datasz, TCHAR** out_data, long* out_datalen);

int decodeHex(TCHAR* in_data, long in_datalen, byte** out_data, long* out_datasz);

/* WAIT MESSAGE */

void showMessage(const TCHAR* str, long bWaitKey);

void showMessageAndWaitForKey(const TCHAR* str);

#endif
