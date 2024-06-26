@echo off & echo Incomplete script. Compile it first via 'build.bat' - github.com/3F/DllExport 1>&2 & exit /B 1


:: /? will cause problems for the call commands below, so we just escape this via supported alternative:
:: TODO: 
if "%~1"=="/?" goto usage

set "dpnx0=%~dpnx0"
set args=%*

:: Escaping '^' is not identical for all cases (DllExport ... vs call DllExport ...)
set ddargs=%*
if defined args (
    if defined __p_call (
        set ddargs=%ddargs:^^=^%
    ) else (
        set args=%args:^=^^%
    )
)
set wMgrArgs=%ddargs%

:: When ~ !args! and "!args!"
:: # call DllExport  ^  - ^
:: #      DllExport  ^  - empty
:: # call DllExport  ^^ - ^^
:: #      DllExport  ^^ - ^

:: When ~ %args%  (disableDelayedExpansion)
:: # call DllExport  ^  - ^^
:: #      DllExport  ^  - ^
:: # call DllExport  ^^ - ^^^^
:: #      DllExport  ^^ - ^^

:: Do not use: ~ "%args%" or %args%  + (enableDelayedExpansion)


:: [I] from scripts:
:: # call DllExport  %%%% - %
:: # call DllExport  %%   - empty
:: # call DllExport  %    - empty
:: # DllExport       %%   - %
:: # DllExport       %    - empty

:: [II] from command-line:
:: # call DllExport   %  -  %
:: # DllExport        %  -  %

set esc=%args:!=^!%
setlocal enableDelayedExpansion

:: https://github.com/3F/DllExport/issues/88
:: For '&':
:: 1. "_=%*" or _="%*"
:: 2.1. _=%* Works correctly only for delayed evaluation inside "...", i.e. don't use "args=%_% "
:: 2.2. Mostly can be safely called only as !args!, i.e. try do not use %args%
::
:: For '!':
:: 1. %~dpnx0 and %cd% in enableDelayedExpansion mode.
:: 1.1. Derivative assignments can be used safely only as !cd!, i.e. a=!cd! ... b=!a! but not as b=%a%
:: !cd! -ok
:: %~dpnx0 via !dpnx0! -ok

set "E_CARET=^"
set "esc=!esc:%%=%%%%!"
set "esc=!esc:&=%%E_CARET%%&!"

:: - - -
:: Settings by default

set "dxpVersion=$-pkg-version-$"
set "wAction=Configure"

:: - - - 

set "dxpName=DllExport"
set "tWizard=tools/net.r_eg.DllExport.Wizard.targets"
set "dxpPackages=packages"
set "pkgSrv=https://www.nuget.org/api/v2/package/"
set "buildInfoFile=build_info.txt"
set "fManager=!dpnx0!"
set "wRootPath=!cd!"

:: -
:: bitwise parameters

set /a wDxpOpt=0

:: -

set "dxpDebug="
set "buildInfo="
set "gMsbPath="
set "pkgLink="
set "peExpList="
set "kForce="
set "mgrUp="
set "proxy="
set "xmgrtest="
set "khMSBuild="


set /a ERROR_SUCCESS=0
set /a ERROR_FAILED=1
set /a ERROR_FILE_NOT_FOUND=2
set /a ERROR_PATH_NOT_FOUND=3

:: Current exit code for endpoint
set /a EXIT_CODE=0

:: - - -
:: Initialization of user arguments

if not defined args (
    if defined wAction goto action
    goto usage
)

call :initargs arg !esc! amax
goto commands

:usage

echo.
@echo .NET DllExport $-version-$
@echo Copyright (c) 2009-2015  Robert Giesecke
@echo Copyright (c) 2016-2024  Denis Kuzmin ^<x-3F@outlook.com^> github/3F
echo.
echo MIT License
@echo https://github.com/3F/DllExport
echo Based on hMSBuild, MvsSln, +GetNuTool: https://github.com/3F
echo.
@echo.
@echo Usage: DllExport [args to DllExport] [args to GetNuTool] [args to hMSBuild]
echo ------
echo.
echo Arguments
echo ---------
echo -action {type} - Specified action for Wizard. Where {type}:
echo   * Configure - To configure DllExport for specific projects.
echo   * Update    - To update pkg reference for already configured projects.
echo   * Restore   - To restore configured DllExport.
echo   * Export    - To export configured projects data.
echo   * Recover   - To re-configure projects via predefined/exported data.
echo   * Unset     - To unset all data from specified projects.
echo   * Upgrade   - Aggregates an Update action with additions for upgrading.
echo.
echo -sln-dir {path}    - Path to directory with .sln files to be processed.
echo -sln-file {path}   - Optional predefined .sln file to be processed.
echo -metalib {path}    - Relative path to meta library.
echo -metacor {path}    - Relative path to meta core library.
echo -dxp-target {path} - Relative path to entrypoint wrapper of the main core.
echo -dxp-version {num} - Specific version of DllExport. Where {num}:
echo   * Versions: 1.7.3 ...
echo   * Keywords: 
echo     `actual` - Unspecified local/latest remote version; 
echo                ( Only if you know what you are doing )
echo.
echo -msb {path}           - Full path to specific msbuild.
echo -hMSBuild {args}      - Access to hMSBuild tool (packed) https://github.com/3F/hMSBuild
echo -packages {path}      - A common directory for packages.
echo -server {url}         - Url for searching remote packages.
echo -proxy {cfg}          - To use proxy. The format: [usr[:pwd]@]host[:port]
echo -pkg-link {uri}       - Direct link to package from the source via specified URI.
echo -force                - Aggressive behavior, e.g. like removing pkg when updating.
echo -no-mgr               - Do not use %~nx0 for automatic restore the remote package.
echo -mgr-up               - Updates %~nx0 to version from '-dxp-version'.
echo -wz-target {path}     - Relative path to entrypoint wrapper of the main wizard.
echo -pe-exp-list {module} - To list all available exports from PE32/PE32+ module.
echo -eng                  - Try to use english language for all build messages.
echo -GetNuTool {args}     - Access to GetNuTool (integrated) https://github.com/3F/GetNuTool
echo -debug                - To show additional information.
echo -version              - Displays version for which (together with) it was compiled.
echo -build-info           - Displays actual build information from selected DllExport.
echo -help                 - Displays this help. Aliases: -help -h
echo.
echo Flags
echo -----
echo  __p_call - To use the call-type logic when invoking %~nx0
echo.
echo Samples
echo -------
echo DllExport -action Configure -force -pkg-link http://host/v1.7.3.nupkg
echo DllExport -action Restore -sln-file "Conari.sln"
echo DllExport -proxy guest:1234@10.0.2.15:7428 -action Configure
echo.
echo DllExport -mgr-up -dxp-version 1.7.3
echo DllExport -action Upgrade -dxp-version 1.7.3
echo.
echo DllExport -GetNuTool /p:ngpackages="Conari;regXwild"
echo DllExport -pe-exp-list bin\Debug\regXwild.dll

goto endpoint

:: - - -
:: Logic for user arguments
:commands

set /a idx=0

:loopargs
set key=!arg[%idx%]!

    :: The help command

    if [!key!]==[-help] ( goto usage ) else if [!key!]==[-h] ( goto usage ) else if [!key!]==[-?] ( goto usage )

    :: Available keys

    if [!key!]==[-debug] ( 

        set dxpDebug=1

        goto continue
    ) else if [!key!]==[-action] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set wAction=!v!
        for %%g in (Restore, Configure, Update, Export, Recover, Unset, Upgrade, Default) do (
            if "!v!"=="%%g" goto continue
        )

        echo Unknown -action !v!
        exit /B %ERROR_FAILED%
        
    ) else if [!key!]==[-sln-dir] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set wSlnDir=!v!

        goto continue
    ) else if [!key!]==[-sln-file] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set wSlnFile=!v!

        goto continue
    ) else if [!key!]==[-metalib] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set wMetaLib=!v!

        goto continue
    ) else if [!key!]==[-metacor] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set wMetaCor=!v!

        goto continue
    ) else if [!key!]==[-dxp-target] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set wDxpTarget=!v!

        goto continue
    ) else if [!key!]==[-dxp-version] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set dxpVersion=!v!

        goto continue
    ) else if [!key!]==[-msb] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set gMsbPath=!v!

        goto continue
    ) else if [!key!]==[-packages] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set dxpPackages=!v!

        goto continue
    ) else if [!key!]==[-server] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set pkgSrv=!v!

        goto continue
    ) else if [!key!]==[-proxy] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set proxy=!v!
        set wProxy=!v!

        goto continue
    ) else if [!key!]==[-pkg-link] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set pkgLink=!v!
        set dxpVersion=!key!

        goto continue
    ) else if [!key!]==[-force] ( 

        set kForce=1

        goto continue
    ) else if [!key!]==[-no-mgr] ( 

        set /a wDxpOpt^|=1

        goto continue
    ) else if [!key!]==[-mgr-up] ( 

        set mgrUp=1

        goto continue
    ) else if [!key!]==[-wz-target] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set tWizard=!v!

        goto continue
    ) else if [!key!]==[-pe-exp-list] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set peExpList=!v!

        goto continue
    ) else if [!key!]==[-eng] ( 

        chcp 437 >nul

        goto continue
    ) else if [!key!]==[-GetNuTool] ( 

        call :ktoolinit -GetNuTool 10
        set /a EXIT_CODE=!ERRORLEVEL! & goto endpoint

    ) else if [!key!]==[-hMSBuild] (

        rem :: we'll wait rcv task below
        set khMSBuild=1 & goto action

    ) else if [!key!]==[-version] ( 

        @echo $-version-$  %__dxp_pv%
        goto endpoint

    ) else if [!key!]==[-build-info] ( 

        set buildInfo=1

        goto continue
    ) else if [!key!]==[-tests] ( set /a "idx+=1" & call :eval arg[!idx!] v
        
        set xmgrtest=!v!

        goto continue
    ) else ( 
        echo Incorrect key: !key!
        set /a EXIT_CODE=%ERROR_FAILED%
        goto endpoint
    )

:continue
set /a "idx+=1" & if %idx% LSS !amax! goto loopargs


:: - - -
:: Main 
:action

call :dbgprint "dxpName = " dxpName
call :dbgprint "dxpVersion = " dxpVersion
call :dbgprint "-sln-dir = " wSlnDir
call :dbgprint "-sln-file = " wSlnFile
call :dbgprint "-metalib = " wMetaLib
call :dbgprint "-metacor = " wMetaCor
call :dbgprint "-dxp-target = " wDxpTarget
call :dbgprint "-wz-target = " tWizard
call :dbgprint "#opt " wDxpOpt

if defined dxpVersion (
    if "!dxpVersion!"=="actual" (
        set "dxpVersion="
    )
)
set wPkgVer=!dxpVersion!

if z%wAction%==zUpgrade (
    call :dbgprint "Upgrade is on"
    set mgrUp=1
    set kForce=1
)

call :trim dxpPackages
set "dxpPackages=!dxpPackages!\\"

set "_remoteUrl=!dxpName!"
set "wPkgPath=!dxpPackages!!dxpName!"

if defined dxpVersion (
    set "_remoteUrl=!_remoteUrl!/!dxpVersion!"
    set "wPkgPath=!wPkgPath!.!dxpVersion!"
)

if defined kForce (
    if exist "!wPkgPath!" (
        call :dbgprint "Removing old version before continue. '-force' key rule. " wPkgPath
        rmdir /S/Q "!wPkgPath!"
    )
)

set wzTarget="!wPkgPath!\\!tWizard!"
call :dbgprint "wPkgPath = " wPkgPath

if not exist !wzTarget! (

    if exist "!wPkgPath!" (
        call :dbgprint "Trying to replace obsolete version ... " wPkgPath
        rmdir /S/Q "!wPkgPath!"
    )

    call :dbgprint "-pkg-link = " pkgLink
    call :dbgprint "-server = " pkgSrv

    if defined pkgLink (
        set pkgSrv=!pkgLink!
        
        :: support of local relative paths
        if "!pkgSrv::=!"=="!pkgSrv!" (
            set pkgSrv=!cd!/!pkgSrv!
        )
        
        :: https://github.com/3F/GetNuTool/issues/6
        if "!wPkgPath::=!"=="!wPkgPath!" ( 
            set "_rlp=../" 
        )
        set "_remoteUrl=:!_rlp!!wPkgPath!|"
    )

    :: https://github.com/3F/DllExport/issues/74
    if defined gMsbPath (
        set gntmsb=-msbuild "!gMsbPath!"
    )

    set _gntC=!gntmsb! /p:ngserver="!pkgSrv!" /p:ngpackages="!_remoteUrl!" /p:ngpath="!dxpPackages!" /p:proxycfg="!proxy! "
    call :dbgprint "GetNuTool call: " _gntC

    REM :: gnt's requirements (1.6.2 and less)
    REM set "_gntC=!_gntC:&=%%E_CARET%%&!"

    if defined dxpDebug (
        call :gntpoint !_gntC!
    ) else (
        call :gntpoint !_gntC! >nul
    )
)

if defined khMSBuild (
    call :ktoolinit -hMSBuild 9
    set /a EXIT_CODE=!ERRORLEVEL! & goto endpoint
)

if defined peExpList (
    "!wPkgPath!\\tools\\PeViewer.exe" -list -pemodule "!peExpList!"

    set /a EXIT_CODE=%ERRORLEVEL%
    goto endpoint
)

if defined buildInfo (
    call :dbgprint "buildInfo = " wPkgPath buildInfoFile

    if not exist "!wPkgPath!\\!buildInfoFile!" (
        echo information about build is not available.
        
        set /a EXIT_CODE=%ERROR_FILE_NOT_FOUND%
        goto endpoint
    )

    type "!wPkgPath!\\!buildInfoFile!"
    goto endpoint
)

if not exist !wzTarget! (
    echo Something went wrong. Try to use another keys.

    set /a EXIT_CODE=%ERROR_FILE_NOT_FOUND%
    goto endpoint
)

call :dbgprint "wRootPath = " wRootPath
call :dbgprint "wAction = " wAction
call :dbgprint "wMgrArgs = " wMgrArgs

if defined gMsbPath (
    call :dbgprint "Use specific MSBuild tools: " gMsbPath

    REM :: keep it inside quotes because of removing in :loopargs
    set xMSBuild="!gMsbPath!"
    goto rundxp
)

call :msbnetf _msb & set xMSBuild="!_msb!"
if "!ERRORLEVEL!"=="0" goto rundxp

echo MSBuild tools was not found. Try with `-msb` key.
set /a EXIT_CODE=%ERROR_FILE_NOT_FOUND%
goto endpoint


:: - - -
:: Wizard
:rundxp

if not defined xMSBuild (
    echo Something went wrong. Use `-debug` key for details.

    set /a EXIT_CODE=%ERROR_FILE_NOT_FOUND%
    goto endpoint
)

if not defined xmgrtest (

    REM :: Possible incorrect Sdk-based project types, https://github.com/3F/DllExport/pull/123
    if not defined gMsbPath if defined wPkgPath (

        set xMSBuild="!wPkgPath!\\hMSBuild"

        :: Only for 1.7.0+ since it includes hmsbuild 2.3
        for /f "tokens=*" %%i in ('!xMSBuild! -version') do set hmsbver=%%i
        call :numver !hmsbver! hmsbver0

        call :dbgprint "hMSBuild -v" hmsbver hmsbver0
        REM :: {2.3}.0.59567+cf86a84 where added -vsw-as key

        if !hmsbver0! GEQ 230 (
            call :dbgprint "2.3+"

            REM :: -prerelease  - https://github.com/3F/DllExport/issues/143
            REM :: -requiresAny - NetCore components will include required Microsoft.Component.MSBuild
            REM :: Microsoft.NetCore.Component.SDK: 16+ / Microsoft.Net.Core.Component.SDK: 15
            REM :: For netfx we don't care about other cases since hMSBuild will return any related instance anyway
            set xMSBuild=!xMSBuild! -vsw-as "-requiresAny -requires Microsoft.NetCore.Component.SDK Microsoft.Net.Core.Component.SDK -products * -latest -prerelease"
        )
    )

    call :dbgprint "Target: " xMSBuild wzTarget
    call !xMSBuild! /nologo /v:m /m:4 !wzTarget!
)


:: - - -
:: Post-actions
:endpoint

if defined xmgrtest ( 
    echo Running Tests ... "!xmgrtest!"

    call :msbnetf _tool
    "!_tool!" /nologo /v:m /m:4 "!xmgrtest!"
    exit /B 0
)

:: keep it as the last one-line command before final exit!
if defined mgrUp (
    (copy /B/Y "!wPkgPath!\\DllExport.bat" "!fManager!" > nul) && ( echo Manager has been updated. & exit /B 0 ) || ( (echo -mgr-up failed:!EXIT_CODE! 1>&2) & exit /B 1 )
)

exit /B !EXIT_CODE!


:: Functions
:: ::

:numver
:: (1) - input number {major}.{minor} e.g. 4.4.1.39906+2465d90 or 4.3.0-RC
:: &2  - normalized number 
set _ver=%~1

    for /f "tokens=1,2 delims=." %%a in ("!_ver!") do (
        set _=%%b & set /a _*=10 & set /a %2=%%a!_!
    )

exit /b 0

:: - - -
:: Initializer of the commands for tools such GetNuTool, hMSBuild, etc.
:ktoolinit
:: 1 - requested tool
:: 2 - length of the key
:: esq - prepared arguments for tool
:: wPkgPath - root pkg path
set key=%~1
set /a klen=%~2

    call :dbgprint "accessing to !key! ..."
    
    :: invoke a tool with arguments from right side
    for /L %%p IN (0,1,8181) DO (
        if "!esc:~%%p,%klen%!"=="!key!" (

            set found=!esc:~%%p!

            :: TODO: up compressor for: call !xktool! !found:~%klen%!
            set kargs=!found:~%klen%!
            
            if defined khMSBuild (
                call "!wPkgPath!\\hMSBuild" !kargs!
            ) else (
                call :gntpoint !kargs!
            )
            
            exit /B !ERRORLEVEL!
        )
    )

    call :dbgprint "!key! is corrupted: " esc

exit /B %ERROR_FAILED%
:: :ktoolinit

:: - - -
:: Tools from .NET Framework - .net 4.0, ...
:msbnetf {out:toolset}
call :dbgprint "Searching from .NET Framework - .NET 4.0, ..."

for %%v in (4.0, 3.5, 2.0) do (
    call :rtools %%v Y & if defined Y ( 
        set %1=!Y!
        exit /B 0 
    )
)

call :dbgprint "msb -netfx: not found"
set "%1="
exit /B %ERROR_FILE_NOT_FOUND%
:: :msbnetf

:rtools {in:version} {out:found}
call :dbgprint "check %1"
    
for /F "usebackq tokens=2* skip=2" %%a in (
    `reg query "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\MSBuild\ToolsVersions\%1" /v MSBuildToolsPath 2^> nul`
) do if exist %%b (
    
    set _msbp=%%~b
    call :dbgprint ":msbfound " _msbp

    call :msbfound _msbp _msbuild

    set %2=!_msbuild!
    exit /B 0
)

set "%2="
exit /B 0
:: :rtools

:msbfound {in:path} {out:fullpath}
set %2=!%~1!\MSBuild.exe
exit /B 0
:: :msbfound

:dbgprint {in:str} [{in:uneval1}, [{in:uneval2}]]
if defined dxpDebug (
    set msgfmt=%1
    set msgfmt=!msgfmt:~0,-1! 
    set msgfmt=!msgfmt:~1!
    echo.[%TIME% ] !msgfmt! !%2! !%3!
)
exit /B 0
:: :dbgprint

:trim {in/out:str}
call :rtrim %1
call :ltrim %1
exit /B 0
:: :trim

:rtrim {in/out:str}
call :_trim %1 "-=1"
exit /B 0
:: :rtrim

:ltrim {in/out:str}
call :_trim %1 "+=1"
exit /B 0
:: :ltrim

:_trim {in/out:str} {in:type}
:: Algo-v2 avoids problems with special symbols.
:: Usage: 1: in/out; 2: "-=1" or "+=1"
:: 
:: remark: this is a more stable way instead of
:: - for() lot of problems especially for '='.
:: - %* is better than for() but too hard to protect 
::      this: '&!~`@#$^(+)_=-;[.]{,}
set ins=z!%1!z
if "%~2"=="-=1" (set "_rt=1") else (set "_rt=")

if defined _rt (
    set /a "i=-2"
) else (
    set /a "i=1"
)

:_tpos
if "!ins:~%i%,1!"==" " (
    set /a "i%~2"
    goto _tpos
)
if defined _rt set /a "i+=1"

if defined _rt (
    set "%1=!ins:~1,%i%!"
) else (
    set "%1=!ins:~%i%,-1!"
)
exit /B 0
:: :_trim

:initargs {in:vname} {in:arguments} {out:index}
:: Usage: 1- the name for variable; 2- input arguments; 3- max index

set "vname=%~1"
set /a idx=-1

:_initargs
:: - 
set /a idx+=1
set %vname%[!idx!]=%~2
:: - 
shift & if not "%~3"=="" goto _initargs
set /a idx-=1

set %1=!idx!
exit /B 0
:: :initargs

:eval {in:unevaluated} {out:evaluated}
:: Usage: 1- input; 2- evaluated output

set %2=!%1!

exit /B 0
:: :eval

:gntpoint
setlocal disableDelayedExpansion 

:: ========================= GetNuTool =========================

