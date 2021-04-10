'use strict';

tripsModule.filter('isTripFinishedFilter', [
    function isTripFinishedFilter() {
        return function (input, isFinished) {
            if (isFinished === undefined || isFinished === false) {
                var notFinishedTrips = [];
                var now = new Date();
                for (var i in input) {
                    if (new Date(input[i]['departureDate']) > now) {
                        notFinishedTrips.push(input[i]);
                    }
                }

                return notFinishedTrips;
            }
            else {
                return input;
            }
        }
    }]);