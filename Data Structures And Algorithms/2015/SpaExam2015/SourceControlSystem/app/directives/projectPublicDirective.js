projectsModule.directive('projectPublicDirective', [function () {
    return {
        restrict: 'A', // Attribute
        templateUrl: 'app/views/directives/projectPublicDirective.html',
        scope: {
            projectModel: '=',
            index: '='
        },
        link: function (scope, element, attributes, controller) {
        },
        replace: false,
        priority: 0,
    };
}]);