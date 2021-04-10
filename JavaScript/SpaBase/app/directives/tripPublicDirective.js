tripsModule.directive('tripPublicDirective', [function () {
    return {
        restrict: 'A', // Attribute
        templateUrl: 'app/views/directives/tripPublicDirective.html',
        scope: {
            tripModel: '=',
            index: '='
        },
        link: function (scope, element, attributes, controller) {
        },
        replace: false,
        priority: 0,
    };
}]);