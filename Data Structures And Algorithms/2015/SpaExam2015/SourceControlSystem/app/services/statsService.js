'use strict';

projectsModule.factory('statsService', ['$http', '$q', 'baseUrl',
    function statsService($http, $q, baseUrl) {
        function getStatistics() {
            var deferred = $q.defer();

            $http.get(baseUrl + 'api/statistics')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function getLatestAddedProjects() {
            var deferred = $q.defer();

            $http.get(baseUrl + 'api/projects')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function getLatestCommits() {
            var deferred = $q.defer();

            $http.get(baseUrl + 'api/commits')
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        return {
            getStatistics: getStatistics,
            getLatestAddedProjects: getLatestAddedProjects,
            getLatestCommits: getLatestCommits,
        };
    }]);