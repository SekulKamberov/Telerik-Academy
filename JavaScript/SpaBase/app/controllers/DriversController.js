
'use strict';

tripsModule.controller('DriversController', ['$scope', '$log', '$routeParams', '$resource', '$location', 'driversService', 'cookiesService',
    function DriversController($scope, $log, $routeParams, $resource, $location, driversService, cookiesService) {
        $scope.driverDetails;
        $scope.driverId = $routeParams.id;
        if ($scope.driverId) {
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
            }

            driversService.getDriverDetails($scope.driverId, cookiesService.getToken())
                    .then(function (data) {
                        $scope.driverDetails = data;
                        console.log(data);
                    })
                    .catch($log.error);
            return;
        }

        $scope.substring;
        $scope.setDriverSubstringFilter = function (newSubstringToFilterWith) {
            $scope.substring = newSubstringToFilterWith;
        }

        // initial drivers load
        $scope.drivers;
        driversService.getDriversByPage(1, cookiesService.getToken())
                .then(function (data) {
                    $scope.page = 1;
                    $scope.drivers = data;
                }, function (error) {
                    $location.path('/error/' + error['message']);
                })
                .catch($log.error);

        $scope.page = 1;
        $scope.getDriversByPage = function (page, userNameContent) {
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
                return;
            }

            if (page <= 0) {
                page = 1;
                $scope.page = 1;
            }

            driversService.getDriversByPage(page, cookiesService.getToken(), userNameContent)
                .then(function (data) {
                    $scope.page = page;
                    $scope.drivers = data;
                }, function (error) {
                    $location.path('/error/' + error['message']);
                })
                .catch($log.error);
        }
    }]);