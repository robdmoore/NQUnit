/// <reference path="jquery-1.4.4-vsdoc.js" />
var MyNamespace = (function ($) {

	var that = {};

	var counter = 0;

	var multiply = function (y) {
		if (!isNaN(y)) {
			counter *= y;
		}
	};

	var add = function (y) {
		if (!isNaN(y)) {
			counter += y * 1;
		}
	};

	var increment = function () {
		add(1);
	};

	var display = function () {
		$("#display").text(counter);
	};

	var getCount = function () {
		return counter;
	};

	var reset = function () {
		counter = 0;
	};

	// Public methods
	that.add = add;
	that.multiply = multiply;
	that.display = display;
	that.increment = increment;
	that.getCount = getCount;
	that.reset = reset;

	return that;
})(jQuery);