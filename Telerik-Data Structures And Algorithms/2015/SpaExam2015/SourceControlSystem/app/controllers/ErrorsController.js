'use strict';

projectsModule.controller('ErrorsController', ['$scope', '$routeParams',
    function ErrorsController($scope, $routeParams) {
        $scope.message = $routeParams.message;
    }]);