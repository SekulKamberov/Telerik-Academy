'use strict';

projectsModule.factory('projectsService', ['$http', '$q', 'baseUrl',
    function projectsService($http, $q, baseUrl) {
        function getLicenses(key) {
            var deferred = $q.defer();
            $http.get(
                baseUrl + 'api/licenses', {
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

        function createProject(project, key) {
            var deferred = $q.defer();

            console.log(project);
            $http.post(
                baseUrl + 'api/projects',
                project, {
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

        function getProjectDetails(projectId, key) {
            var deferred = $q.defer();

            $http.get(
                baseUrl + 'api/projects/' + projectId,
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

        function getProjectsFilteredPaged(page, pageSize, filter, orderBy, orderType, byUser, onlyPublic, key) {
            var deferred = $q.defer();
            var url = baseUrl + 'api/projects/all' +
                '?page=' + page +
                '&pageSize=' + pageSize +
                '&filter=' + filter +
                '&orderBy=' + orderBy +
                '&orderType=' + orderType +
                '&byUser=' + byUser +
                '&onlyPublic=' + onlyPublic;

            $http.get(
                url,
                {
                    headers: { 'Authorization': "Bearer " + key }
                })
                .success(function (data) {
                    console.log(data);
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function addColaborator(colaborator, projectId, key) {
            var deferred = $q.defer();

            $http({
                method: 'GET',
                url: baseUrl + 'api/projects/' + projectId,
                colaborator: colaborator,
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

        function getColaborators(projectId, key) {
            var deferred = $q.defer();

            $http.get(
                baseUrl + 'api/projects/collaborators/' + projectId,
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
            getLicenses: getLicenses,
            createProject: createProject,
            getProjectDetails: getProjectDetails,
            getProjectsFilteredPaged: getProjectsFilteredPaged,
            addColaborator: addColaborator,
            getColaborators: getColaborators,
        };
    }]);