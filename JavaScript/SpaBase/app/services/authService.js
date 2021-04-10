'use strict';

tripsModule.factory('authService', ['$http', '$q', 'baseUrl',
    function authService($http, $q, baseUrl) {
        function register(user) {
            var deferred = $q.defer();

            $http.post(
                baseUrl + 'api/users/register',
                user,
                {
                    headers: { 'Content-Type': 'application/json' }
                })
                .success(function (data) {
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function login(user) {
            var deferred = $q.defer();
            $http.post(baseUrl + 'api/users/login', 'username=' + user.username + '&password=' + user.password + '&grant_type=password', { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } })
                .success(function (data) {
                    //$http.defaults.headers.common.Authorization = 'Bearer ' + data['access_token']; // send it with every request
                    deferred.resolve(data);
                })
                .error(function (error) {
                    deferred.reject(error);
                });
            return deferred.promise;
        }

        function logout(key) {
            var deferred = $q.defer();
            $http({
                method: 'POST',
                url: baseUrl + 'api/users/logout',
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

        function getUserInfo(key) {
            var deferred = $q.defer();
            $http({
                method: 'GET',
                url: baseUrl + 'api/users/userInfo',
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

        return {
            register: register,
            login: login,
            logout: logout,
            getUserInfo: getUserInfo,
        };
    }]);