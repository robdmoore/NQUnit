# Build solution in release mode before running this
% Pass in version as commandline argument
.nuget\nuget.exe pack NQUnit\NQUnit.nuspec -version %1
.nuget\nuget.exe pack NQUnit.NUnit\NQUnit.NUnit.nuspec -version %1