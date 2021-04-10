'use strict';

projectsModule.controller('InfoController', ['$scope', 'baseUrl',
    function InfoController($scope, baseUrl) {
        $scope.baseUrl = baseUrl;
    }]);