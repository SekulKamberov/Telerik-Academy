'use strict';

var projectsModule = angular
    .module('projectsModule', ['ngRoute', 'ngResource', 'ngCookies', 'ngSanitize', 'angular-loading-bar'])
    .config(function ($routeProvider) {
        
        $routeProvider
            .when('/', {
                templateUrl: 'app/views/partials/home.html',
            }).when('/register', {
                templateUrl: 'app/views/partials/register.html'
            }).when('/login', {
                templateUrl: 'app/views/partials/login.html'
            }).when('/userInfo', {
                templateUrl: 'app/views/partials/userInfo.html'
            }).when('/projects', {
                templateUrl: 'app/views/partials/projects.html',
                resolve: {
                    authorize: ['cookiesService', '$location', function (cookiesService, $location) {
                        if (!cookiesService.isLoged()) {
                            $location.path('/unauthorized');
                        }
                    }]
                }
            }).when('/projects/add', {
                templateUrl: 'app/views/partials/createProject.html',
                resolve: {
                    authorize: ['cookiesService', '$location', function (cookiesService, $location) {
                        if (!cookiesService.isLoged()) {
                            $location.path('/unauthorized');
                        }
                    }]
                }
            }).when('/projects/:projectId/', {
                templateUrl: 'app/views/partials/projectDetails.html',
                resolve: {
                    authorize: ['cookiesService', '$location', function (cookiesService, $location) {
                        if (!cookiesService.isLoged()) {
                            $location.path('/unauthorized');
                        }
                    }]
                }
            }).when('/commits/:id/', {
                templateUrl: 'app/views/partials/commitDetails.html',
                resolve: {
                    authorize: ['cookiesService', '$location', function (cookiesService, $location) {
                        if (!cookiesService.isLoged()) {
                            $location.path('/unauthorized');
                        }
                    }]
                }

            }).when('/projects/:id/addcommits', {
                templateUrl: 'app/views/partials/addCommit.html',
                resolve: {
                    authorize: ['cookiesService', '$location', function (cookiesService, $location) {
                        if (!cookiesService.isLoged()) {
                            $location.path('/unauthorized');
                        }
                    }]
                }
            }).when('/unauthorized', {
                templateUrl: 'app/views/partials/unauthorized.html'
            }).when('/error', {
                templateUrl: 'app/views/partials/error.html'
            }).when('/error/:message/', {
                templateUrl: 'app/views/partials/error.html'
            });

        $routeProvider.otherwise({ redirectTo: '/' });
    })
    .value('jQuery', jQuery)
    .value('examName', 'Spa Apps')
    .value('licenses', [])
    .constant('institution', 'Telerik Academy')
    .constant('baseUrl', 'http://spa.bgcoder.com/');