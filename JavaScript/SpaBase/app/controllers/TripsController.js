'use strict';

tripsModule.controller('TripsController', ['$scope', '$log', '$routeParams', '$resource', '$location', 'tripsService', 'cookiesService', 'cities',
    function TripsController($scope, $log, $routeParams, $resource, $location, tripsService, cookiesService, cities) {
        $scope.orderBy = 'date';
        $scope.orderType = 'asc';
        $scope.from;
        $scope.to;
        $scope.isFinished = false;
        $scope.onlyMineTrips = false;

        $scope.cities;
        if (cities.length === 0) {
            tripsService.getCities()
                        .then(function (data) {
                            cities.push.apply(cities, data);
                            $scope.cities = cities;
                        })
                        .catch($log.error);
        }
        else {
            $scope.cities = cities;
        }

        $scope.message;
        $scope.error;

        $scope.createTrip = function (trip, form) {
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
                return;
            }

            if (form.$valid) {
                var tripInfo = {
                    "from": trip.from,
                    "to": trip.to,
                    "availableSeats": trip.availableSeats,
                    "departureTime": trip.departureTime
                }

                tripsService.createTrip(tripInfo, cookiesService.getToken())
                    .then(function (data) {
                        //console.log(data);
                        //console.log(data.id);
                        //$scope.message = 'Trip added successfully!';
                        $location.path('/trips/' + data.id);
                    }, function (error) {
                        $scope.error = error.message;
                    })
                    .catch($log.error);
            }

            if (form.$invalid) {
                $scope.message = 'Invalid form data!';
            }
        }

        $scope.joinTrip = function (tripId) {
            console.log(tripId);
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
                return;
            }

            tripsService.joinTrip(tripId, cookiesService.getToken())
                    .then(function (data) {
                        console.log(data);
                        $location.path('/trips');
                    })
                    .catch($log.error);
        }

        $scope.tripDetails;
        $scope.tripId = $routeParams.id;
        if ($scope.tripId) {
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
            }

            tripsService.getTripDetails($scope.tripId, cookiesService.getToken())
                    .then(function (data) {
                        $scope.tripDetails = data;
                        console.log(data);
                    })
                    .catch($log.error);

            return;
        }

        // initial trips load
        $scope.trips;
        tripsService.getTripsByPageOnly(1, cookiesService.getToken())
                .then(function (data) {
                    $scope.page = 1;
                    $scope.trips = data;
                }, function (error) {
                    $location.path('/error/' + error['message']);
                })
                .catch($log.error);

        $scope.page = 1;

        $scope.getTripsByPageOnly = function (page) {
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
                return;
            }

            if (page <= 0) {
                page = 1;
                $scope.page = 1;
            }

            tripsService.getTripsByPageOnly(page, cookiesService.getToken())
                .then(function (data) {
                    $scope.page = page;
                    $scope.trips = data;
                }, function (error) {
                    $location.path('/error/' + error['message']);
                })
                .catch($log.error);
        }

        $scope.getTripsFilteredPaged = function (page, orderBy, orderType, from, to, isFinished, onlyMineTrips) {
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
                return;
            }

            if (page <= 0) {
                page = 1;
                $scope.page = 1;
            }

            tripsService.getTripsFilteredPaged(page, orderBy, orderType, from, to, isFinished, onlyMineTrips, cookiesService.getToken())
                .then(function (data) {
                    $scope.page = page;
                    $scope.trips = data;
                }, function (error) {
                    $location.path('/error/' + error['message']);
                })
                .catch($log.error);
        }

        function selectIntersections(firstArray, secondArray) {
            var newArray = [];
            if (firstArray.length === 0 || secondArray.length === 0) {
                return newArray;
            }

            for (var i = 0; i < firstArray.length; i++) {
                for (var j = 0; j < secondArray.length; j++) {
                    if (firstArray[i]['id'] === secondArray[j]['id']) {
                        newArray.push(firstArray[i]);
                        break;
                    }
                }
            }

            return newArray;
        }
    }]);