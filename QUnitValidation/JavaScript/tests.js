/// <reference path="lib/jquery-1.4.4-vsdoc.js" />
/// <reference path="lib/json2.js" />
/// <reference path="lib/qunit.js" />
/// <reference path="lib/specit.js" />
/// <reference path="lib/jquery.mockjax.js" />
$(document).ready(function () {
	describe("Example test suite", function() {
		it("should pass", function() {
			assert("a string").should(eql, "a string");
		});
		it("should fail", function() {
			assert("a string").should(eql, "wrong string");
		});
	});
});
