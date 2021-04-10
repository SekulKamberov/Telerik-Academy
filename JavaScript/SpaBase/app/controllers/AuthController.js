'use strict';

tripsModule.controller('AuthController',
    ['$scope', '$http', '$log', '$cookieStore', '$routeParams', '$resource', '$location', 'authService', 'sha1Service', 'cookiesService',
function AuthController($scope, $http, $log, $cookieStore, $routeParams, $resource, $location, authService, sha1Service, cookiesService) {
        $scope.isLogedIn = false;
        $scope.userLabel = "";
        $scope.userInfo;

        if (cookiesService.isLoged()) {
            authService.getUserInfo(cookiesService.getToken())
                .then(function (data) {
                    $scope.userLabel = data.email;
                    $scope.userInfo = data;
                    console.log(data);
                })
                .catch($log.error);
            $scope.isLogedIn = true;
        }

        $scope.register = function (user, form) {
            if (form.$valid) {
                if (user.password != user.confirmPassword) {
                    return;
                }

                var hashedPassword = sha1Service.hash(user.password);
                if (user.isDriver != true) {
                    user.car = '';
                }

                var userInfo = {
                    "email": user.name,
                    "password": hashedPassword,
                    "confirmPassword": hashedPassword,
                    "isDriver": user.isDriver,
                    "car": user.car
                }
                authService.register(userInfo)
                    .then(function (data) {
                        console.log(data);
                        $location.path('/');
                    }, function (error) {
                        $location.path('/error/' + error.modelState[''][0]);
                    })
                    .catch($log.error);
            }
            if (form.$invalid) {
                console.log("Not valid form");
            }
        }

        $scope.login = function (user, form) {
            if (form.$valid) {
                if (cookiesService.isLoged()) {
                    $scope.isLogedIn = true;
                    $location.path('/home');
                    return;
                }

                var hashedPassword = sha1Service.hash(user.password);
                var userInfo = {
                    "username": user.username,
                    "password": hashedPassword,
                }

                authService.login(userInfo)
                    .then(function (data) {
                        cookiesService.logToken(data['access_token']);
                        $scope.isLogedIn = true;
                        $scope.userLabel = data.userName;
                        $location.path('/home');
                    }, function (error) {
                        $location.path('/error/' + error['error_description']);
                    })
                    .catch($log.error);
            }

            if (form.$invalid) {
                console.log("Not valid form");
            }
        }

        $scope.logout = function () {
            if (cookiesService.isLoged() === false) {
                $scope.userLabel = '';
                $scope.userInfo = '';
                $location.path('/home');
                return;
            }

            authService.logout(cookiesService.getToken())
                .then(function (data) {
                    cookiesService.deleteToken();
                    $scope.isLogedIn = false;
                    $scope.userLabel = "";
                    $location.path('/home');
                }, function (error) {
                    $location.path('/error/' + error['message']);
                })
                .catch($log.error);
        }
        
        $scope.getUserInfo = function () {
            if (cookiesService.isLoged() === false) {
                return;
            }

            authService.getUserInfo(cookiesService.getToken())
                .then(function (data) {
                    console.log(data);
                    $scope.userInfo = data;
                }, function (error) {
                    $location.path('/error/' + error['message']);
                })
                .catch($log.error);
        }
    }]
);