jQuery QUnit in .NET
====================

Runs QUnit tests inside .NET by using WatiN.

Based on [Joshua Flanagan's original work](http://www.lostechies.com/blogs/joshuaflanagan/archive/2008/09/18/running-jquery-qunit-tests-under-continuous-integration.aspx), but updated to work with the latest version of WatiN (2.0.5 at the time of writing) and QUnit.

There is also an extension to get the QUnit tests working in NUnit. It is easy to copy this extension and change it to work with your favourite unit testing framework.

Tested on
---------

 * ReSharper NUnit test runner (unfortunately the separate QUnit tests don't show up as separate NUnit tests on the ReSharper test runner due to limitations of the runner)
 * Test-driven.NET NUnit test runner
 * NUnit test runner
 * TeamCity NUnit test runner (you need to ensure TeamCity can interact with the desktop (if it's run as a service, alternatively you can run TeamCity is run from a .bat file); see [this Stack Overflow thread](http://stackoverflow.com/questions/488443/running-watin-on-teamcity/3415992#3415992))

Requirements
------------

You need Internet Explorer so WatiN can fire up an instance to test the QUnit test page(s).