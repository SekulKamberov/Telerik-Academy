'use strict';

tripsModule.factory('tripsService', ['$http', '$q', 'baseUrl',
    function tripsService($http, $q, baseUrl) {
        function getCities() {
            var deferred = $q.defer();
            $http.get(baseUrl + 'api/cities')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function createTrip(trip, key) {
            var deferred = $q.defer();

            $http.post(
                baseUrl + 'api/trips',
                trip, {
                    headers: { 'Authorization': "Bearer " + key }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function getTripDetails(tripId, key) {
            var deferred = $q.defer();

            $http.get(
                baseUrl + 'api/trips/' + tripId,
                {
                    headers: { 'Authorization': "Bearer " + key }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function joinTrip(tripId, key) {
            console.log('T' + tripId);
            console.log('K' + key);
            var deferred = $q.defer();

            $http({
                method: 'PUT',
                url: baseUrl + 'api/trips/' + tripId,
                headers: {
                    'Authorization': "Bearer " + key
                }
            })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function getTripsFilteredPaged(page, orderBy, orderType, from, to, isFinished, onlyMineTrips, key) {
            var deferred = $q.defer();
            var url = baseUrl + 'api/trips/?page=' + page +
                '&orderBy=' + orderBy +
                '&orderType=' + orderType +
                '&finished=' + isFinished +
                '&onlyMine=' + onlyMineTrips;
            if (from !== undefined) {
                url += '&from=' + from;
            }

            if (to !== undefined) {
                url += '&to=' + to;
            }

            $http.get(
                url,
                {
                    headers: { 'Authorization': "Bearer " + key }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function getTripsOrderedPaged(page, orderBy, orderType, key) {
            var deferred = $q.defer();
            var url = baseUrl + 'api/trips/?page=' + page +
                '&orderBy=' + orderBy +
                '&orderType=' + orderType;
            $http.get(
                url,
                {
                    headers: { 'Authorization': "Bearer " + key }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }
        
        function getTripsByPageOnly(page, key) {
            var deferred = $q.defer();
            var url = baseUrl + 'api/trips/?page=' + page;
            $http.get(
                url,
                {
                    headers: { 'Authorization': "Bearer " + key }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }
        
        function getTripsFromToPaged(page, from, to, key) {
            var deferred = $q.defer();
            var url = baseUrl + 'api/trips/?page=' + page +
                '&from=' + from +
                '&to=' + to;
            $http.get(
                url,
                {
                    headers: { 'Authorization': "Bearer " + key }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function getFinishedTripsPaged(page, isFinished, key) {
            var deferred = $q.defer();
            var url = baseUrl + 'api/trips/?page=' + page +
                '&finished=' + isFinished;
            $http.get(
                url,
                {
                    headers: { 'Authorization': "Bearer " + key }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function getMyTripsPaged(page, onlyMineTrips, key) {
            var deferred = $q.defer();
            var url = baseUrl + 'api/trips/?page=' + page +
                '&onlyMine =' + onlyMineTrips;
            $http.get(
                url,
                {
                    headers: { 'Authorization': "Bearer " + key }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        return {
            getCities: getCities,
            createTrip: createTrip,
            getTripDetails: getTripDetails,
            joinTrip: joinTrip,
            getTripsFilteredPaged: getTripsFilteredPaged,
            getTripsByPageOnly: getTripsByPageOnly,
            getTripsOrderedPaged: getTripsOrderedPaged,
            getTripsFromToPaged: getTripsFromToPaged,
            getFinishedTripsPaged: getFinishedTripsPaged,
            getMyTripsPaged: getMyTripsPaged,
        };
    }]);