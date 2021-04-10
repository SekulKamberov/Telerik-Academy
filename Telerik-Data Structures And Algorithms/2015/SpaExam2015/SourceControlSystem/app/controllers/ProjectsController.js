'use strict';

projectsModule.controller('ProjectsController', ['$scope', '$log', '$routeParams', '$resource', '$location', 'projectsService', 'commitsService', 'cookiesService', 'licenses',
    function ProjectsController($scope, $log, $routeParams, $resource, $location, projectsService, commitsService, cookiesService, licenses) {
        $scope.page = 1;
        $scope.pageSize = 10;
        $scope.filter = '';
        $scope.orderBy = 'date';
        $scope.orderType = 'asc';
        $scope.byUser = '';
        $scope.onlyPublic = true;

        $scope.licenses;
        if (licenses.length === 0) {
            projectsService.getLicenses(cookiesService.getToken())
                        .then(function (data) {
                            licenses.push.apply(licenses, data);
                            $scope.licenses = licenses;
                        })
                        .catch($log.error);
        }
        else {
            $scope.licenses = licenses;
        }

        $scope.message;
        $scope.error;

        $scope.createProject = function (project, form) {
            console.log(project);
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
                return;
            }

            if (form.$valid) {
                var projectInfo = {
                    "name": project.name,
                    "description": project.description,
                    "licenseId": project.licenseId,
                    "private": project.private
                }

                projectsService.createProject(projectInfo, cookiesService.getToken())
                    .then(function (data) {
                        console.log('PROJECT CREATED');
                        console.log(data);
                        $location.path('/projects/' + data);
                    }, function (error) {
                        $scope.error = error.message;
                    })
                    .catch($log.error);
            }

            if (form.$invalid) {
                $scope.message = 'Invalid form data!';
            }
        }

        $scope.commitPage = 1;
        $scope.commitPageSize = 10;
        $scope.commitUser = '';
        $scope.projectCommits;
        $scope.projectDetails;
        $scope.projectColaborators;
        $scope.projectId = $routeParams.projectId;
        if ($scope.projectId) {
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
            }

            projectsService.getProjectDetails($scope.projectId, cookiesService.getToken())
                    .then(function (data) {
                        $scope.projectDetails = data;
                        console.log(data);
                    })
                    .catch($log.error);

            projectsService.getColaborators($scope.projectId, cookiesService.getToken())
                    .then(function (data) {
                        $scope.projectColaborators = data;
                        console.log('Çolaborators');
                        console.log(data);
                    })
                    .catch($log.error);

            commitsService.getCommits($scope.commitPage, $scope.commitPageSize, $scope.commitUser = '', $scope.projectId, cookiesService.getToken())
                    .then(function (data) {
                        console.log('COMMITS 1');
                        console.log(data);
                        $scope.projectCommits = data;
                    })
                    .catch($log.error);
        }

        // initial projects load
        $scope.projects;
        projectsService.getProjectsFilteredPaged($scope.page, $scope.pageSize, $scope.filter, $scope.orderBy, $scope.orderType, $scope.byUser, $scope.onlyPublic, cookiesService.getToken())
                .then(function (data) {
                    $scope.projects = data;
                }, function (error) {
                    $location.path('/error/' + error['message']);
                })
                .catch($log.error);

        $scope.getProjectsFilteredPaged = function (page, pageSize, filter, orderBy, orderType, byUser, onlyPublic) {
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
                return;
            }

            if (page <= 0) {
                page = 1;
                $scope.page = 1;
            }

            projectsService.getProjectsFilteredPaged(page, pageSize, filter, orderBy, orderType, byUser, onlyPublic, cookiesService.getToken())
                .then(function (data) {
                    $scope.page = page;
                    $scope.projects = data;
                }, function (error) {
                    $location.path('/error/' + error['message']);
                })
                .catch($log.error);
        }

        $scope.getCommits = function (commitPage, commitPageSize, commitUser, projectId) {
            if (!cookiesService.isLoged()) {
                $location.path('/unauthorized');
                return;
            }

            if (commitPage <= 0) {
                commitPage = 1;
                $scope.commitPage = 1;
            }

            commitsService.getCommits(commitPage, commitPageSize, commitUser, projectId, cookiesService.getToken())
                    .then(function (data) {
                        console.log('THE COMMITS');
                        console.log(data);
                        $scope.projectCommits = data;
                        $scope.commitPage = commitPage;
                    }, function (error) {
                        $location.path('/error/' + error['message']);
                    })
                    .catch($log.error);
        }

        $scope.addColaborator = function (colaborator, projectId, form) {
            if (form.$valid) {
                var colaborator = {
                    'colaborator': colaborator,
                };

                projectsService.addColaborator(colaborator, projectId, cookiesService.getToken())
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
    }]);