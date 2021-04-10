'use strict';

tripsModule.filter('takeNameFromMailFilter', [
    function takeNameFromMailFilter() {
        return function (input) {
            var indexOfAt = input.indexOf('@');
            if (indexOfAt == -1) {
                return input;
            }

            var name = input.substring(0, indexOfAt);
            return name;
        }
}]);