(function () {
    'use strict';

    angular
        .module('paylocityapp')
        .controller('premiumController', premiumController);

    premiumController.$inject = ['$scope', '$http'];

    function premiumController($scope, $http) {
        $scope.title = 'premiumController';
        $scope.person = { IsEmployee: false };
        $scope.employeeExists = false;
        $scope.coveredPlanPeople = [];

        activate();

        function activate() {
            $scope.coveredPlanPeople = getCoveredParticipants();
        }

        function checkForEmployee(data) {
            angular.forEach(data, function (person) {
                if (person.IsEmployee) {
                    $scope.employeeExists = true;
                }
            });
        }

        function getCoveredParticipants() {
            $http.get('/api/PremiumQuotes')
                .success(function (data) {
                    checkForEmployee(data);
                    $scope.coveredParticipants = data;
                });
        }

        $scope.addPerson = function (person) {
            $http.post('/api/PremiumQuotes', $scope.person)
                .success(function (data) {
                    checkForEmployee(data);
                    $scope.coveredParticipants = data;
                    $scope.person = { IsEmployee: false };
            });
        }

        $scope.reinitializeSession = function () {
            $http.put('/api/PremiumQuotes')
                .success(function (data) {
                    $scope.coveredParticipants = data;
                    $scope.person = { IsEmployee: false };
                    $scope.employeeExists = false;
                });
        }

        
    }
})();