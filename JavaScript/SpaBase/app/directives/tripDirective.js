tripsModule.directive('tripDirective', [function () {
    return {
        restrict: 'A', // Attribute
        templateUrl: 'app/views/directives/tripDirective.html',
        scope: {
            model: '=',
            isLoged: '='
        },
        link: function (scope, element, attributes, controller) {
            //console.log(scope.model);
            //console.log(element);
        },
        replace: false,
        priority: 0,
    };
}]);