NQUnit.NUnit
------------

Example project to get you up and running with NQUnit using the NUnit test runner quickly.

Getting started
===============

1. Install the NQUnit.NUnit package (already done)
2. Set all of the files within the JavaScriptTests\ and JavaScriptTests\Scripts folders to "Copy if newer" so they get copied to the output directory and can be found by the test runner
3. Set the "Embed Interop Types" setting to false for the "Interop.SHDocVw" reference for the project otherwise you will get a "Unhandled Exception: System.IO.FileLoadException: Could not load file or assembl y 'Interop.SHDocVw...'" error
4. Run the tests using an NUnit runner of choice

Adding a new test
=================

Copy/rename JavaScriptTests\blank.html and JavaScriptTests\blank.js to create tests. Add as many .html files as you like to the JavaScriptTests folder to add new tests (they will autoamtically be picked up) - just remember to set them all as "Copy if newer".

Advanced usage / Using other test runners
=========================================

Inspect the files in JavaScriptTests\NQUnit to tweak the integration and to see how you might do it for different test runners.
