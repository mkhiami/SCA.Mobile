(function () {
    'use strict';
    //localStorageService



    angular.module('app').service("dataService", ['common', 'webStorage', dataService]);


    function dataService(common, webStorage) {
        var isLogged = false;
        var accessToken, userName = '';
        var userInfo = {};
        this.setToken = function (token, user) {
            accessToken = token;
            userName = user;
            webStorage.add('token', accessToken);
            webStorage.add('userName', userName);
            console.log('Is Supported? ' + webStorage.isSupported);
            isLogged = true;
        }
        this.setInfo = function (data) {
            userInfo = data;
            webStorage.add('userInfo', data);
            console.log('Set storage userInfo');
        }
        this.isAuthenticated = function () {
            console.log('Storage Token is: ' + webStorage.get('token'));
            if (webStorage.get('token') != null) return webStorage.get('token') != null;

            return isLogged;
        }
        this.getToken = function () {
            if (webStorage.get('token') != null) return webStorage.get('token');
            return accessToken;
        }
        this.getUserName = function () {
            if (webStorage.get('userName') != null) return webStorage.get('userName');

            return userName;
        }
        this.getInfo = function () {
            console.log('Storage userInfo is: ' + webStorage.get('userInfo'));

            if (webStorage.get('userInfo') != null) return webStorage.get('userInfo');


            return userInfo;
        }
        return this;
    }
})();