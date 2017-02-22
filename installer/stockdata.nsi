; stockdata.nsi
;
; This script is perhaps one of the simplest NSIs you can make. All of the
; optional settings are left to their default settings. The installer simply 
; prompts the user asking them where to install, and drops a copy of example1.nsi
; there. 

!cd ..\stockdata\bin\Release

;--------------------------------
Unicode true

; The name of the installer
Name "종목데이터분석기"

; The file to write
OutFile "stockdata_setup.exe"

; The default installation directory
InstallDir $APPDATA\StockData

; Request application privileges for Windows Vista
RequestExecutionLevel user

;--------------------------------

; Pages

Page directory
Page instfiles

;--------------------------------

LoadLanguageFile "${NSISDIR}\Contrib\Language files\English.nlf"
LoadLanguageFile "${NSISDIR}\Contrib\Language files\Korean.nlf"

LangString Name ${LANG_ENGLISH} "English"
LangString Name ${LANG_KOREAN} "Korean"


; The stuff to install
Section "" ;No components page, name is not important

  ; Set output path to the installation directory.
  SetOutPath $INSTDIR

  ; Put file there
  File Newtonsoft.Json.dll
  File Newtonsoft.Json.xml
  File stockdata.exe
  File stockdata.exe.config

  CreateShortCut "$Desktop\종목데이터분석기.lnk" "$INSTDIR\stockdata.exe" "" "$INSTDIR\stockdata.exe" 0
  ;CreateShortCut "$Desktop\종목데이터분석기.lnk" "$INSTDIR\stockdata.exe"

SectionEnd ; end the section
