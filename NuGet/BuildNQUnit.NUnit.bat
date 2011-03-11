REM Set environment variables for NQUnit.NUnit
SET PROJECT=NQUnit.NUnit
SET ASSEMBLYNAME=none
REM Copy static content files
copy /y "..\NQUnit.NUnit\JavaScriptTests\" "NQUnit.NUnit\JavaScriptTests\"
REM Build NQUnit.NUnit NuGet package
rake