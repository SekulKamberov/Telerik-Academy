'use strict'

tripsModule.factory('cookiesService', ['$cookieStore',
    function cookiesService($cookieStore) {
        function isLoged() {            
            if ($cookieStore.get('access_token')) {
                return true;
            }

            return false;
        }

        function logToken(token) {
            return $cookieStore.put('access_token', token);
        }

        function getToken() {
            return $cookieStore.get('access_token');
        }

        function deleteToken() {
            return $cookieStore.remove('access_token');
        }

        return {
            isLoged: isLoged,
            logToken: logToken,
            getToken: getToken,
            deleteToken: deleteToken,
        };
    }]);