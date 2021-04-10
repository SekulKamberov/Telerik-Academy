'use strict';

tripsModule.factory('driversService', ['$http', '$q', 'baseUrl',
    function driversService($http, $q, baseUrl) {
        function getDriverDetails(driverId, key) {
            var deferred = $q.defer();

            $http.get(
                baseUrl + 'api/drivers/' + driverId,
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

        function getDriversByPage(page, key, userNameContent) {
            var deferred = $q.defer();
            var url = baseUrl + 'api/drivers/?page=' + page;
            if (userNameContent) {
                url += '&username=' + userNameContent;
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

        return {
            getDriverDetails: getDriverDetails,
            getDriversByPage: getDriversByPage,
        };
    }]);