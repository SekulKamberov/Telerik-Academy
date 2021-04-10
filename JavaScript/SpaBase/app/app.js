'use strict';

var tripsModule = angular
    .module('tripsModule', ['ngRoute', 'ngResource', 'ngCookies', 'ngSanitize', 'angular-loading-bar'])
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
            }).when('/trips', {
                templateUrl: 'app/views/partials/trips.html'
            }).when('/trips/create', {
                templateUrl: 'app/views/partials/createTrip.html'
            }).when('/trips/:id/', {
                templateUrl: 'app/views/partials/tripDetails.html'
            }).when('/drivers', {
                templateUrl: 'app/views/partials/drivers.html'
            }).when('/drivers/:id/', {
                templateUrl: 'app/views/partials/driverDetails.html'
            }).when('/unauthorized', {
                templateUrl: 'app/views/partials/unauthorized.html'
            }).when('/error', {
                templateUrl: 'app/views/partials/error.html'
            }).when('/error/:message/', {
                templateUrl: 'app/views/partials/error.html'
            }).when('/private', {
                templateUrl: 'app/views/partials/private.html',
                resolve: {
                    authorize: ['cookiesService', '$location', function (cookiesService, $location) {
                        if (!cookiesService.isLoged())
                        {
                            $location.path('/unauthorized');
                        }
                    }]
                }
            });

        // REDIRECT when route is wrong
        $routeProvider.otherwise({ redirectTo: '/' });
    })
    .value('jQuery', jQuery) // Use it as dependancy in controller, service, directive ...
    .value('examName', 'Spa Apps')
    .value('cities', [])
    .constant('institution', 'Telerik Academy')
    //.constant('baseUrl', 'http://localhost:1234/');
    .constant('baseUrl', 'http://spa2014.bgcoder.com/');

// .run('$routeScope', '$location', 'cookieService', run)

//var routeResolveChecks = routeResolversProvider.$get();

//var run = function run($routeScope, $location, cookieService) {
//    $routeScope.$on('$routeChangeError', function (ev, current, previous, rejection) {
//        if (!cookieService.isLoged()) {
//            $location.path('/login');
//        }
//    });
//};