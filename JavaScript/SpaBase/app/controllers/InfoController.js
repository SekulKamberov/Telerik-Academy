'use strict';

tripsModule.controller('InfoController', ['$scope', 'baseUrl',
    function InfoController($scope, baseUrl) {
        $scope.baseUrl = baseUrl;
    }]);