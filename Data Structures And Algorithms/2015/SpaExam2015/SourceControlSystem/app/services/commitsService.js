'use strict';

projectsModule.factory('commitsService', ['$http', '$q', 'baseUrl',
    function commitsService($http, $q, baseUrl) {

        function commit(commit, key) {
            var deferred = $q.defer();

            $http({
                method: 'GET',
                url: baseUrl + 'api/commits/',
                commit: commit,
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

        function getCommits(page, pageSize, filter, projectId, key) {
            var deferred = $q.defer();
            var url = baseUrl + 'api/commits/byproject/' + projectId + '/' +
                '?Page=' + page +
                '&PageSize=' + pageSize +
                '&ByUser=' + filter;
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

        function getCommitDetails(projectId, key) {
            var deferred = $q.defer();

            $http.get(
                baseUrl + 'api/commits/' + projectId,
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
            commit: commit,
            getCommits: getCommits,
            getCommitDetails: getCommitDetails
        };
    }]);