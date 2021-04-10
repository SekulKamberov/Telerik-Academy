tripsModule.directive('datePickerDirective',  [ function () {
    return {
        restrict: 'A', // Attribute
        templateUrl: 'app/views/directives/datePickerDirective.html',
        scope: {
            model: '=',
            id: '=',
        },
        link: function(scope, element, attributes, controller){
            //console.log(scope.model);
            //console.log(scope.id);
            //console.log(element);
        },
        replace: true,
        priority: 0,
    };
}]);