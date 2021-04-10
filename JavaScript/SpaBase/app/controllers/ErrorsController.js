'use strict';

tripsModule.controller('ErrorsController', ['$scope', '$routeParams',
    function ErrorsController($scope, $routeParams) {
        $scope.message = $routeParams.message;
    }]);