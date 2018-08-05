# 종목데이터분석
> TSV(Tab-separated values) 파일 처리기

대신증권 HTS의 텍스트로 저장 기능으로 저장한 TSV(Tab-separated values) 파일을 적절하게 처리하여 투자에 도움을 주는 것을 목적으로 함.

이 프로그램은 Windows PC용 클라이언트 프로그램이며, 데이터를 저장하는 중앙 서버 프로그램이 있어야 동작한다.

1. x86으로 컴파일해야 한다.
2. 관리자 권한으로 실행해야 한다.
* 프로그램 실행 시 자동으로 관리자 권한을 부여하기 위해서는 프로젝트 우클릭 -> 추가 -> 새 항목 -> 응용프로그램 매니페스트 파일(app.manifest)을 추가하고 trustInfo/security/requestedPrivileges/requestedExecutionLevel 태그의 level 값을 requireAdministrator 로 변경한다.

## Build

* Microsoft(R) Visual Studio Community 2015
* .Net Framework 4.5.2
* C#

## Installation

Windows:

```
Download setup file and execute it
```

## Release History

* 1.0
    * 첫 릴리즈

## External Resources


## Author

Yotta

Distributed under the GPLv3 license. See ``LICENSE`` for more information.

[https://github.com/yottacho/stockdata](https://github.com/yottacho/stockdata)

