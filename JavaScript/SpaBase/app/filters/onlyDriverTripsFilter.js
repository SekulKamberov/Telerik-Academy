'use strict';

tripsModule.filter('onlyDriverTripsFilter', [
    function onlyDriverTripsFilter() {
        return function (input, onlyDriverTrips, driverName) {
            if (onlyDriverTrips === true) {
                var driverTrips = [];
                for (var i in input) {
                    if (input[i]['driverName'] === driverName) {
                        driverTrips.push(input[i]);
                    }
                }

                return driverTrips;
            }
            else {
                return input;
            }
        }
    }]);