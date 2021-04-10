'use strict';

tripsModule.factory('statsService', ['$http', '$q', 'baseUrl',
    function statsService($http, $q, baseUrl) {
        function getTripsStatistics() {
            var deferred = $q.defer();

            $http.get(baseUrl + 'api/stats')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function getLatestTrips() {
            var deferred = $q.defer();

            $http.get(baseUrl + 'api/trips')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function getLatestDrivers() {
            var deferred = $q.defer();

            $http.get(baseUrl + 'api/drivers')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        return {
            getTripsStatistics: getTripsStatistics,
            getLatestTrips: getLatestTrips,
            getLatestDrivers: getLatestDrivers,
        };
    }]);