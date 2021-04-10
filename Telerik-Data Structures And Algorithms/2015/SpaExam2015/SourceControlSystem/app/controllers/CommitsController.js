'use strict';

projectsModule.controller('CommitsController', ['$scope', '$log', '$routeParams', '$resource', '$location', 'commitsService', 'cookiesService', 'licenses',
    function CommitsController($scope, $log, $routeParams, $resource, $location, commitsService, cookiesService, licenses) {
        $scope.id;
        $scope.id = $routeParams.id;
        $scope.projectId = $scope.id;

        $scope.commit = function (projectId, sourceCode, form) {
            if (form.$valid) {
                var commit = {
                    'projectId': projectId,
                    'sourceCode': sourceCode,
                };

                commitsService.commit(commit, cookiesService.getToken())
                    .then(function (data) {
                        console.log(data);
                        $location.path('/projects/' + projectId + '/');
                    }, function (error) {
                        $location.path('/error/' + error.modelState[''][0]);
                    })
                    .catch($log.error);
            }

            if (form.$invalid) {
                console.log("Not valid form");
            }
        }

        $scope.commitId = $routeParams.id;

        $scope.commitDetails;

        if ($scope.commitId) {
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
            }

            commitsService.getCommitDetails($scope.commitId, cookiesService.getToken())
                    .then(function (data) {
                        $scope.commitDetails = data;
                        console.log(data);
                    })
                    .catch($log.error);
        }

    }]);