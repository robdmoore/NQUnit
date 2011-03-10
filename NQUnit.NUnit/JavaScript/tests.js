/// <reference path="lib/jquery-1.4.4-vsdoc.js" />
/// <reference path="lib/json2.js" />
/// <reference path="lib/qunit.js" />
/// <reference path="lib/specit.js" />
/// <reference path="../../SampleWebApp/Scripts/my-javascript.js" />
/// <reference path="lib/jquery.mockjax.js" />
$(function () {

	describe("MyNamespace.increment()", function () {

		it("should change count from 0 to 1", function () {
			assert(MyNamespace.getCount()).should(eql, 0);
			MyNamespace.increment();
			assert(MyNamespace.getCount()).should(eql, 1);
		});

		it("should change count from 0 to 2 when called twice", function () {
			assert(MyNamespace.getCount()).should(eql, 0);
			MyNamespace.increment();
			MyNamespace.increment();
			assert(MyNamespace.getCount()).should(eql, 2);
		});

		after(function () {
			MyNamespace.reset();
		});
	});

	describe("MyNamespace.display()", function () {

		it("should display 0 by default", function () {
			assert($("#display").text()).should(eql, "");
			MyNamespace.display();
			assert($("#display").text()).should(eql, "0");
		});

		it("should display counter when modified", function () {
			MyNamespace.increment();
			MyNamespace.display();
			assert($("#display").text()).should(eql, "1");
		});

		after(function () {
			MyNamespace.reset();
		});
	});

	describe("MyNamespace.add()", function () {

		it("should change count from 0 to 1 when adding 1", function () {
			MyNamespace.add(1);
			assert(MyNamespace.getCount()).should(eql, 1);
		});

		it("should change count from 0 to 2 when adding 2", function () {
			MyNamespace.add(2);
			assert(MyNamespace.getCount()).should(eql, 2);
		});

		it("should leave count when adding 0", function () {
			MyNamespace.add(0);
			assert(MyNamespace.getCount()).should(eql, 0);
		});

		it("should change count from 0 to -1 when adding -1", function () {
			MyNamespace.add(-1);
			assert(MyNamespace.getCount()).should(eql, -1);
		});

		it("should leave count as 0 when adding string", function () {
			MyNamespace.add("string");
			assert(MyNamespace.getCount()).should(eql, 0);
		});

		it("should change count to 5 when adding '5'", function () {
			MyNamespace.add("5");
			assert(MyNamespace.getCount()).should(eql, 5);
		});

		after(function () {
			MyNamespace.reset();
		});
	});

	describe("MyNamespace.multiply()", function () {

		it("should leave count as 0 when multiplying by 1", function () {
			MyNamespace.multiply(1);
			assert(MyNamespace.getCount()).should(eql, 0);
		});

		it("should leave count as 0 when multiplying by -1", function () {
			MyNamespace.multiply(-1);
			assert(MyNamespace.getCount()).should(eql, 0);
		});

		it("should leave count as 1 when multiplying by 1", function () {
			MyNamespace.increment();
			MyNamespace.multiply(1);
			assert(MyNamespace.getCount()).should(eql, 1);
		});

		it("should change count from 1 to 2 when multiplying by 2", function () {
			MyNamespace.increment();
			MyNamespace.multiply(2);
			assert(MyNamespace.getCount()).should(eql, 2);
		});

		it("should change count from 2 to 4 when multiplying by 2", function () {
			MyNamespace.increment();
			MyNamespace.increment();
			MyNamespace.multiply(2);
			assert(MyNamespace.getCount()).should(eql, 4);
		});

		it("should change count from 1 to 0 when multiplying by 0", function () {
			MyNamespace.increment();
			MyNamespace.multiply(0);
			assert(MyNamespace.getCount()).should(eql, 0);
		});

		it("should change count from 1 to -1 when multiplying by -1", function () {
			MyNamespace.increment();
			MyNamespace.multiply(-1);
			assert(MyNamespace.getCount()).should(eql, -1);
		});

		it("should change count from 2 to -2 when multiplying by -1", function () {
			MyNamespace.increment();
			MyNamespace.increment();
			MyNamespace.multiply(-1);
			assert(MyNamespace.getCount()).should(eql, -2);
		});

		it("should leave count as 0 when multiplying by string", function () {
			MyNamespace.multiply("string");
			assert(MyNamespace.getCount()).should(eql, 0);
		});

		it("should leave count as 1 when multiplying by string", function () {
			MyNamespace.increment();
			MyNamespace.multiply("string");
			assert(MyNamespace.getCount()).should(eql, 1);
		});

		it("should change count from 1 to 5 when multiplying by '5'", function () {
			MyNamespace.increment();
			MyNamespace.multiply(0);
			assert(MyNamespace.getCount()).should(eql, 0);
		});

		after(function () {
			MyNamespace.reset();
		});
	});
});
