(function () {
    'use strict';
  
    angular
    .module('premiumService')
    .factory('Premiums', factory);

    factory.$inject = ['$http'];

    function factory($http) {
        var service = {
            getData: getData
        };

        return service;

        function getData() { }
    }


})();