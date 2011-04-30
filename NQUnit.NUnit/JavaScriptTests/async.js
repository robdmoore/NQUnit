/// <reference path="Scripts/jquery-1.4.4-vsdoc.js" />
/// <reference path="Scripts/qunit.js" />
$(function () {
	asyncTest("Should pass", function () {
		setTimeout(function () {
			start();
			ok(true);
		}, 2000);
	});
	asyncTest("Should pass2", function () {
		setTimeout(function () {
			start();
			ok(true);
		}, 3000);
	});
});
