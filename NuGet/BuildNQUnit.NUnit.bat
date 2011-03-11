REM Set environment variables for NQUnit.NUnit
SET PROJECT=NQUnit.NUnit
SET ASSEMBLYNAME=none
REM Copy static content files
xcopy /y/s/e "..\NQUnit.NUnit\JavaScriptTests" "NQUnit.NUnit\content\JavaScriptTests\"
copy /y "nqunit.nunit.readme.txt" "NQUnit.NUnit\content\"
del "NQUnit.NUnit\content\JavaScriptTests\test.html"
del "NQUnit.NUnit\content\JavaScriptTests\tests.js"
REM Build NQUnit.NUnit NuGet package
rake