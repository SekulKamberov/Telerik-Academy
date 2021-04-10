'use strict';

projectsModule.filter('onlyPublicProjectsFilter', [
    function onlyPublicProjectsFilter() {
        return function (input, onlyPublic) {
            return input;

            // TODO

            if (onlyPublic === true) {
                var publicTrips = [];
                for (var i in input) {
                    if (input[i]['isPublic'] === true) {
                        publicTrips.push(input[i]);
                    }
                }

                return publicTrips;
            }
            else {
                return input;
            }
        }
    }]);