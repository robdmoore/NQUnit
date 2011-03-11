REM Set environment variables for NQUnit.NUnit
SET PROJECT=NQUnit.NUnit
SET ASSEMBLYNAME=none
REM Copy static content files
xcopy /y/s/e "..\NQUnit.NUnit\JavaScriptTests" "NQUnit.NUnit\JavaScriptTests\"
del "NQUnit.NUnit\JavaScriptTests\test.html"
del "NQUnit.NUnit\JavaScriptTests\tests.js"
REM Build NQUnit.NUnit NuGet package
rake