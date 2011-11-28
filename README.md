jQuery QUnit in .NET
====================

Runs QUnit tests inside .NET by using WatiN.

Based on [Joshua Flanagan's original work](http://www.lostechies.com/blogs/joshuaflanagan/archive/2008/09/18/running-jquery-qunit-tests-under-continuous-integration.aspx), but updated to work with the latest version of WatiN (2.0.5 at the time of writing) and QUnit.

There is also an extension to get the QUnit tests working in NUnit. It is easy to copy this extension and change it to work with your favourite unit testing framework.

Installation
------------

 * [http://nuget.org/List/Packages/NQUnit](http://nuget.org/List/Packages/NQUnit)
 * [http://nuget.org/List/Packages/NQUnit.NUnit](http://nuget.org/List/Packages/NQUnit.NUnit)

Documentation
-------------

[http://robdmoore.id.au/blog/2011/03/13/nqunit-javascript-testing-within-net-ci/](http://robdmoore.id.au/blog/2011/03/13/nqunit-javascript-testing-within-net-ci/)

### Asynchronous test timeouts

When calling the `NQUnit.GetTests()` method there is a `maxWaitInMs` parameter, that by default is set to -1 (if you don't specify it), this parameter has the following effect:

 * If -1 (or any number less than 0), then the test suite will wait forever for any asynchronous QUnit tests that you have to finish. Note: if your tests don't return then your test runner will need to be force quit.
 * If 0, then any asynchronous QUnit tests that you have will fail since the test suite will grab the test results of the page as soon as the page finishes loading.
 * Any other number will be the maximum time in ms after the page has finished loading that the test suite will wait for any asynchronous tests to complete.

### HTML Boilerplate

In addition to the standard QUnit boilerplate in your HTML, you will need to include a "Mark of the Web" as follows:
    <!-- saved from url=(0014)about:internet -->
This instructs Internet Explorer to allow Javascript execution even though the page is opened locally.

### Configuring WatiN

There are a couple of configuration options that have been exposed for WatiN, e.g.:

    [TestFixtureSetUp]
    public void SetupFixture()
    {
        global::NQUnit.NQUnit.HideBrowserWindow = true;
        global::NQUnit.NQUnit.ClearCacheBeforeRunningTests = true;
    }

The two configuration options so far are:

 * **HideBrowserWindow**: Set to true to stop the Internet Explorer window popping up and stealing focus away from your test runner (if you are initially running your tests then it would be advisable to not hide the window until you are sure they run correctly).
 * **ClearCacheBeforeRunningTests**: Set to true to clear the cache in Internet Explorer before tests are run (use this if you are having trouble with caching).

They are shown above in a test fixture setup because you can only set these properties once for your whole test run since they are static properties so setting them will apply to all tests.

Compilation
-----------

In order to make the solution compile you will need to create a file NQUnit\NQUnit.snk using [sn.exe](http://msdn.microsoft.com/en-us/magazine/cc163583.aspx) or [Visual Studio](http://msdn.microsoft.com/en-us/library/ms247123.aspx) (or remove the option to strongly sign the NQUnit assembly).

Tested on
---------

 * ReSharper NUnit test runner (unfortunately the separate QUnit tests don't show up as separate NUnit tests on the ReSharper test runner due to limitations of the runner)
 * Test-driven.NET NUnit test runner
 * NUnit test runner
 * TeamCity NUnit test runner (you need to ensure TeamCity can interact with the desktop (if it's run as a service, alternatively you can run TeamCity is run from a .bat file); see [this Stack Overflow thread](http://stackoverflow.com/questions/488443/running-watin-on-teamcity/3415992#3415992))

Requirements
------------

You need Internet Explorer so WatiN can fire up an instance to test the QUnit test page(s).

Questions / additions / problems / etc.
---------------------------------------

 * Send me a pull request
 * Comment on the blog post linked to in the documentation above
 * Email me at: me (at) robdmoore (dot) id (dot) au
 * Raise an issue in the issue tracker