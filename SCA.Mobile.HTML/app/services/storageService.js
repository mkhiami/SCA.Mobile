angular.module('app')
	.factory('storageService', function () {
	    'use strict';

	    var STORAGE_ID = 'correspondenceStorage-angularjs';

	    return {
	        get: function () {
	            return JSON.parse(localStorage.getItem(STORAGE_ID) || '[]');
	        },

	        put: function (todos) {
	            localStorage.setItem(STORAGE_ID, JSON.stringify(todos));
	        }
	    };
	});